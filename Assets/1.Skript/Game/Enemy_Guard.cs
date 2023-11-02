using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Enemy_Guard : CreatureController
{
    private State state = State.Idle;

    private NavMeshAgent agent; // ��ΰ�� AI ������Ʈ
    private Animator anim; // �ִϸ����� ������Ʈ

    public Transform attackRoot;
    public Transform eyeTransform;
    public float attackRange = 1.5f;

    private AudioSource audioSource; // ����� �ҽ� ������Ʈ
    public AudioClip hitClip; // �ǰݽ� ����� �Ҹ�
    public AudioClip deathClip; // ����� ����� �Ҹ�
    public AudioClip shieldClip;
    public AudioClip swingVoice;
    public AudioClip swingClip;

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
    

    CreatureController targetEntity; // ������ ���

    public LayerMask playerLayer; // ���� ��� ���̾�
    public LayerMask shieldLayer; // ���� ��� ���̾�
    LayerMask whatIsTarget;

    private RaycastHit[] hits = new RaycastHit[10];

    private bool shieldHitRegistered = false;

    private bool hasTarget => targetEntity != null && !targetEntity.dead;
    private State previousState; // �ǰ� ���� ���� ���¸� �����ϴ� ����

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        if (attackRoot != null)
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
            Gizmos.DrawRay(attackRoot.position, transform.forward * attackRange);
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
        audioSource = GetComponent<AudioSource>();
        skinRenderer = GetComponentInChildren<Renderer>();
        var attackPivot = attackRoot.position;
        attackPivot.y = transform.position.y;
        attackDistance = Vector3.Distance(attackRoot.position, attackPivot) + attackRange * 0.5f;
        agent.stoppingDistance = attackDistance;
        agent.speed = patrolSpeed;
        whatIsTarget = playerLayer | shieldLayer;
        PlayertargetEntity = GameObject.Find("Player").GetComponent<CreatureController>();
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

        if ((state == State.AttackBegin || state == State.Attacking) && targetEntity != null)
        {
            var lookRotation =
                Quaternion.LookRotation(targetEntity.transform.position - transform.position, Vector3.up);
            var targetAngleY = lookRotation.eulerAngles.y;

            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngleY,
                                        ref turnSmoothVelocity, turnSmoothTime);
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
                if (state == State.Idle)
                {
                    state = State.Tracking;
                    agent.speed = runSpeed;
                }
                // ���� ��� ���� : ��θ� �����ϰ� AI �̵��� ��� ����
                agent.SetDestination(targetEntity.transform.position);
            }
            else
            {
                // Ÿ���� ���� ��� Idle ���¸� �����ϸ� �� ���� ������ ����
                targetEntity = null;

                if (state != State.Idle)
                {
                    state = State.Idle;
                    agent.isStopped = true; // ������Ʈ�� ���� ���·� ����
                }

                // �� ���� ����
                var colliders = Physics.OverlapSphere(eyeTransform.position, viewDistance, whatIsTarget);
                foreach (var collider in colliders)
                {
                    if (!IsTargetOnSight(collider.transform)) continue;

                    var potentialTarget = collider.GetComponent<CreatureController>();
                    if (potentialTarget != null && !potentialTarget.dead)
                    {
                        targetEntity = potentialTarget;
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
            if (targetEntity != null)
            {
                state = State.Tracking; // ���� ���·� ����
            }
        }

        EffectManager.Instance.PlayHitEffect(damageMessage.hitPoint, damageMessage.hitNormal, transform, EffectManager.EffectType.Flesh);
        audioSource.PlayOneShot(hitClip);

        return true;
    }


    public void BeginAttack()
    {
        state = State.AttackBegin;

        agent.isStopped = true;
        anim.SetTrigger("Attack");
        audioSource.PlayOneShot(swingVoice);
    }

    public void EnableAttack()
    {
        state = State.Attacking;

        RaycastHit hit;

        if (Physics.Raycast(attackRoot.position, transform.forward, out hit, attackRange, whatIsTarget))
        {
            var hitCollider = hit.collider;
            var attackTargetEntity = hit.collider.GetComponent<CreatureController>();

            if ((shieldLayer.value & (1 << hit.collider.gameObject.layer)) != 0)
            {
                HandleShieldHit();
                return; // �߰� ���� ó�� �ߴ�
            }
            else if (attackTargetEntity != null)
            {
                var message = new DamageMessage();
                message.amount = damage;
                message.damager = gameObject;
                message.hitPoint = hit.point;
                message.hitNormal = attackRoot.TransformDirection(hit.normal);
                audioSource.PlayOneShot(swingClip);
                Manager.Haptic.Haptic(transform);

                attackTargetEntity.ApplyDamage(message);
            }
        }
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
        if (deathClip != null) audioSource.PlayOneShot(deathClip);
    }

    public void HandleShieldHit()
    {
        // �̹� ���п� ��Ʈ�� ��� �� �̻� ó������ ����
        if (shieldHitRegistered) return;

        // ���п� ��Ʈ ó���� �ߴٴ� ǥ��
        shieldHitRegistered = true;

        // ����� ���
        if (audioSource != null && shieldClip != null)
        {
            audioSource.PlayOneShot(shieldClip);
        }
        else
        {
            Debug.Log("audioSource or shieldClip is null");
        }

        // ���� �ð� �Ŀ� shieldHitRegistered�� �ٽ� false�� ����
        StartCoroutine(ResetShieldHit());
    }
    private IEnumerator ResetShieldHit()
    {
        yield return new WaitForSeconds(0.5f); // ��ٿ� �ð�
        shieldHitRegistered = false;
    }

    public void FootStep()
    {
        if (audioSource != null && footStepClip != null)
        {
            audioSource.PlayOneShot(footStepClip);
        }
    }
}
