using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Monster : CreatureController
{
    public GameObject target;
    [SerializeField]
    public float _hp = 100;
    [SerializeField]
    float _scanRange = 10f;
    [SerializeField]
    float _attackRange = 5f;

    [SerializeField]
    float moveSpeed = 10f;


    CapsuleCollider bodyCol;
    SphereCollider headCol;
    bool isDamaged = false;
    bool isDead = false;
    bool isAttack = false;
    NavMeshAgent agent;

    //public AudioClip hitAudio;
    AudioSource audioSource;
    ParticleSystem hitPaticle;



    public override void Init()
    {
        bodyCol = GetComponentInChildren<CapsuleCollider>();
        headCol = GetComponentInChildren<SphereCollider>();
        audioSource = GetComponent<AudioSource>();
        hitPaticle = GetComponent<ParticleSystem>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    protected override void UpdateIdle()
    {
        if (target == null)
            return;

        float distance = (target.transform.position - transform.position).magnitude;
        if (distance < _scanRange)
        {
            _lockTarget = target;
            Debug.Log($" {_lockTarget.name} in Idle");
            state = State.Moving;
            return;
        }
    }

    protected override void UpdateMoving()
    {
        if (_lockTarget != null)
        {
            _destPos = _lockTarget.transform.position; 
            float distance = (_destPos - transform.position).magnitude;
            if (distance <= _attackRange)
            {
                agent.SetDestination(transform.position);
                state = State.Attack;
                
                return;
            }
        }


        //�̵�
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            state = State.Idle;
        }
        else
        {
            agent.SetDestination(_destPos);
            agent.speed = moveSpeed;
            agent.acceleration = moveSpeed * 2f;
            agent.angularSpeed = 300f;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }
    }
 

    protected override void UpdateAttack()
    {
        if(_lockTarget == null) return;

        if (!isAttack) // ���� ���� �ƴ� ���� �ڷ�ƾ�� ����
        {
            StartCoroutine(AttackRoutine());
        }
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.forward * (_attackRange-0.5f), Color.red);
        Vector3 dir = _lockTarget.transform.position - transform.position;
        Quaternion quat = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
    }

    IEnumerator AttackRoutine()
    {
        isAttack = true;
        anim.CrossFade("Attack", 0.05f, -1, 0);
        yield return new WaitForSeconds(2.0f);
        isAttack = false;
    }


    public void OnHitEvent()
    {
        if (_lockTarget == null)
        {
            state = State.Idle;
        }
        else
        {
            float distance = (_lockTarget.transform.position - transform.position).magnitude;
            if (distance <= _attackRange)
            {
                state = State.Attack;
            }

            else
            {
                state = State.Moving;
            }
        }

        RaycastHit hit;
        Vector3 rayOrigin = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
        Vector3 rayDirection = transform.forward * 10f;  // ���� �������� 10 ����

        Physics.Raycast(rayOrigin, rayDirection, out hit, _attackRange + 1f);
        if (hit.collider == null) return;
        Debug.Log(hit.collider);
        if (hit.collider.CompareTag("Player"))
        {
            AnimationController _player = hit.collider.GetComponent<AnimationController>();
            Debug.Log("���̰� " + hit.collider.name + "�� �浹�߽��ϴ�.");

            if (_player != null)
            {
                _player._hp -= 20;
                Debug.Log($"_hp {_hp}");

            }
        }
    }


    #region Hit
    public void SetDamageFlag()
    {
        isDamaged = true;
    }

    public void ResetDamageFlag()
    {
        isDamaged = false;
    }

    public void TakeDamage(float damage, Collider hitBox)
    {

        _hp -= damage;
        HitEffect();
        Debug.Log($"����ü��{_hp}");

        if (_hp <= 0 && !isDead)
        {
            state = State.Die;
        }


        SetDamageFlag();
        hitBox.enabled = false;
        StartCoroutine(ResetDamageFlagCoroutine(hitBox));

    }

    protected override void UpdateDie()
    {
 
    }

    public void HitEffect()
    {
        hitPaticle.Play();
    }

    IEnumerator ResetDamageFlagCoroutine(Collider hitBox)
    {
        yield return new WaitForSeconds(1.5f);
        hitBox.enabled = true;
        ResetDamageFlag();
    }

   

    #endregion
}
