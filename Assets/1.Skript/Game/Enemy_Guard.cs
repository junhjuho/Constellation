using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Enemy_Guard : CreatureController
{
    private enum State
    {
        Patrol,
        Tracking,
        AttackBegin,
        Attacking,
        Hit,
        Dead,
    }

    private State state;

    private NavMeshAgent agent; // ��ΰ�� AI ������Ʈ
    private Animator anim; // �ִϸ����� ������Ʈ

    public Transform attackRoot;
    public Transform eyeTransform;

    private AudioSource audioPlayer; // ����� �ҽ� ������Ʈ
    public AudioClip hitClip; // �ǰݽ� ����� �Ҹ�
    public AudioClip deathClip; // ����� ����� �Ҹ�

    private Renderer skinRenderer; // ������ ������Ʈ

    public float runSpeed = 10f;
    [Range(0.01f, 2f)] public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public float damage = 30f;
    public float attackRadius = 2f;
    private float attackDistance;

    public float fieldOfView = 50f;
    public float viewDistance = 10f;
    public float patrolSpeed = 3f;
    public CreatureController PlayertargetEntity; // ������ ���


    CreatureController targetEntity; // ������ ���

    public LayerMask whatIsTarget; // ���� ��� ���̾�


    private RaycastHit[] hits = new RaycastHit[10];
    private List<CreatureController> lastAttackedTargets = new List<CreatureController>();

    private bool hasTarget => targetEntity != null && !targetEntity.dead;
    private State previousState; // �ǰ� ���� ���� ���¸� �����ϴ� ����

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        if (attackRoot != null)
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
            Gizmos.DrawSphere(attackRoot.position, attackRadius);
        }

        if (eyeTransform != null)
        {
            var leftRayRotation = Quaternion.AngleAxis(-fieldOfView * 0.5f, Vector3.up);
            var leftRayDirection = leftRayRotation * transform.forward;
            Handles.color = new Color(1f, 1f, 1f, 0.2f);
            Handles.DrawSolidArc(eyeTransform.position, Vector3.up, leftRayDirection, fieldOfView, viewDistance);
        }
    }

#endif

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        skinRenderer = GetComponentInChildren<Renderer>();

        var attackPivot = attackRoot.position;
        attackPivot.y = transform.position.y;
        attackDistance = Vector3.Distance(attackRoot.position, attackPivot) + attackRadius * 2.0f;
        agent.stoppingDistance = attackDistance;
        agent.speed = patrolSpeed;
    }

    // �� AI�� �ʱ� ������ �����ϴ� �¾� �޼���
    public void Setup(float health, float damage, float runSpeed, float patrolSpeed, Color skinColor)
    {
        // ü�� ����
        this.startingHealth = health;
        this.health = health;

        // ����޽� ������Ʈ�� �̵� �ӵ� ����
        this.runSpeed = runSpeed;
        this.patrolSpeed = patrolSpeed;

        this.damage = damage;

        // �������� ������� ���׸����� �÷��� ����, ���� ���� ����
        skinRenderer.material.color = skinColor;
    }

    private void Start()
    {
        // ���� ������Ʈ Ȱ��ȭ�� ���ÿ� AI�� ���� ��ƾ ����
        StartCoroutine(UpdatePath());
    }

    private void Update()
    {
        if (dead) return;

        if (state == State.Tracking)
        {
            var distance = Vector3.Distance(targetEntity.transform.position, transform.position);
            if (distance <= attackDistance)
            {
                agent.velocity = Vector3.zero;
                BeginAttack();
            }
        }
        // ���� ����� ���� ���ο� ���� �ٸ� �ִϸ��̼��� ���
        anim.SetFloat("Speed", agent.desiredVelocity.magnitude);
    }

    private void FixedUpdate()
    {
        if (dead) return;

        if (state == State.AttackBegin || state == State.Attacking)
        {
            var lookRotation =
                Quaternion.LookRotation(targetEntity.transform.position - transform.position, Vector3.up);
            var targetAngleY = lookRotation.eulerAngles.y;

            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngleY,
                                        ref turnSmoothVelocity, turnSmoothTime);
        }

        if (state == State.Attacking)
        {
            var direction = transform.forward;
            var deltaDistance = agent.velocity.magnitude * Time.deltaTime;

            var size = Physics.SphereCastNonAlloc(attackRoot.position, attackRadius, direction, hits, deltaDistance, whatIsTarget);

            for (var i = 0; i < size; i++)
            {
                var attackTargetEntity = hits[i].collider.GetComponent<CreatureController>();

                if (attackTargetEntity != null && !lastAttackedTargets.Contains(attackTargetEntity))
                {
                    var message = new DamageMessage();
                    message.amount = damage;
                    message.damager = gameObject;

                    if (hits[i].distance <= 0f)
                    {
                        message.hitPoint = attackRoot.position;
                    }
                    else
                    {
                        message.hitPoint = hits[i].point;
                    }

                    message.hitNormal = attackRoot.TransformDirection(hits[i].normal);

                    attackTargetEntity.ApplyDamage(message);

                    lastAttackedTargets.Add(attackTargetEntity);
                    break;
                }
            }
        }
    }

    // �ֱ������� ������ ����� ��ġ�� ã�� ��θ� ����
    private IEnumerator UpdatePath()
    {
        // ����ִ� ���� ���� ����
        while (!dead)
        {
            if (hasTarget)
            {
                if (state == State.Patrol)
                {
                    state = State.Tracking;
                    agent.speed = runSpeed;
                }
                // ���� ��� ���� : ��θ� �����ϰ� AI �̵��� ��� ����
                agent.SetDestination(targetEntity.transform.position);
            }
            else
            {
                if (targetEntity != null) targetEntity = null;

                if (state != State.Patrol)
                {
                    state = State.Patrol;
                    agent.speed = patrolSpeed;
                }

                if (agent.remainingDistance <= 2f)
                {
                    var patrolPosition = Utility.GetRandomPointOnNavMesh(transform.position, 20f, NavMesh.AllAreas);
                    agent.SetDestination(patrolPosition);
                }

                // 20 ������ �������� ���� ������ ���� �׷�����, ���� ��ġ�� ��� �ݶ��̴��� ������
                // ��, whatIsTarget ���̾ ���� �ݶ��̴��� ���������� ���͸�
                var colliders = Physics.OverlapSphere(eyeTransform.position, viewDistance, whatIsTarget);

                // ��� �ݶ��̴����� ��ȸ�ϸ鼭, ����ִ� LivingEntity ã��
                foreach (var collider in colliders)
                {
                    if (!IsTargetOnSight(collider.transform)) continue;

                    var livingEntity = collider.GetComponent<CreatureController>();

                    // LivingEntity ������Ʈ�� �����ϸ�, �ش� LivingEntity�� ����ִٸ�,
                    if (livingEntity != null && !livingEntity.dead)
                    {
                        // ���� ����� �ش� LivingEntity�� ����
                        targetEntity = livingEntity;

                        // for�� ���� ��� ����
                        break;
                    }
                }
            }

            // 0.2 �� �ֱ�� ó�� �ݺ�
            yield return new WaitForSeconds(0.1f);
        }
    }

    // �������� �Ծ����� ������ ó��
    public override bool ApplyDamage(DamageMessage damageMessage)
    {
        if (!base.ApplyDamage(damageMessage)) return false;

        //�ǰݵǾ��µ� Ÿ���� ������
        if (targetEntity == null)
        {
            targetEntity = PlayertargetEntity;
        }

        EffectManager.Instance.PlayHitEffect(damageMessage.hitPoint, damageMessage.hitNormal, transform, EffectManager.EffectType.Flesh);
        audioPlayer.PlayOneShot(hitClip);

        return true;
    }


    public void BeginAttack()
    {
        state = State.AttackBegin;

        agent.isStopped = true;
        anim.SetTrigger("Attack");
    }

    public void EnableAttack()
    {
        state = State.Attacking;

        lastAttackedTargets.Clear();
    }

    public void DisableAttack()
    {
        if (hasTarget)
        {
            state = State.Tracking;
        }
        else
        {
            state = State.Patrol;
        }

        if (agent != null && agent.isOnNavMesh)
        {
            agent.isStopped = false;
        }

    }

    private bool IsTargetOnSight(Transform target)
    {
        var direction = target.position - eyeTransform.position;
        direction.y = eyeTransform.forward.y;

        if (Vector3.Angle(direction, eyeTransform.forward) > fieldOfView * 0.5f)
        {
            return false;
        }

        direction = target.position - eyeTransform.position;

        RaycastHit hit;

        if (Physics.Raycast(eyeTransform.position, direction, out hit, viewDistance, whatIsTarget))
        {
            if (hit.transform == target) return true;
        }

        return false;
    }

    // ��� ó��
    public override void Die()
    {
        // LivingEntity�� Die()�� �����Ͽ� �⺻ ��� ó�� ����
        base.Die();


        state = State.Dead;

        // �ٸ� AI���� �������� �ʵ��� �ڽ��� ��� �ݶ��̴����� ��Ȱ��ȭ
        GetComponent<Collider>().enabled = false;

        // AI ������ �����ϰ� ����޽� ������Ʈ�� ��Ȱ��ȭ
        agent.enabled = false;
        anim.SetTrigger("Die");

        // ��� �ִϸ��̼� ���
        anim.applyRootMotion = true;


        // ��� ȿ���� ���
        if (deathClip != null) audioPlayer.PlayOneShot(deathClip);
    }
}
