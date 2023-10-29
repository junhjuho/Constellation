using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreatureController : MonoBehaviour
{

    [SerializeField]
    protected Vector3 _destPos;

    //[SerializeField]
    //protected States _state = States.Idle;

    [SerializeField]
    protected GameObject _lockTarget;

    //protected Animator animator;

    public float startingHealth = 100f; // ���� ü��
    public float health { get; protected set; } // ���� ü��
    public bool dead { get; protected set; } // ��� ����

    public event Action OnDeath; // ����� �ߵ��� �̺�Ʈ

    private const float minTimeBetDamaged = 0.1f;
    private float lastDamagedTime;

    private void Start()
    {
        //Init();
    }

/*    public enum States
    {
        Idle,
        Moving,
        Attack,
        Damaged,
        Die,
    }

    public virtual States state
    {
        get { return _state; }
        set
        {
            _state = value;

            
            switch (_state)
            {
                case States.Die:
                    animator.CrossFade("Death", 0.1f);
                    break;
                case States.Idle:
                    animator.CrossFade("Idle", 0.1f);
                    break;
                case States.Moving:
                    animator.CrossFade("Run", 0.05f);

                    break;
                case States.Attack:

                    break;
                case States.Damaged:
                    
                    break;

            }
        }
    }


    public void Update()
    {
        switch (state)
        {
            case States.Die:
                UpdateDie();
                break;

            case States.Moving:
                UpdateMoving();
                break;

            case States.Idle:
                UpdateIdle();
                break;

            case States.Attack:
                UpdateAttack();
                break;

            case States.Damaged:
                UpdateDamaged();
                break;
        }
    }*/

    //public abstract void Init();
    protected virtual void UpdateDie() { }
    protected virtual void UpdateMoving() { }
    protected virtual void UpdateIdle() { }
    protected virtual void UpdateAttack() { }
    protected virtual void UpdateDamaged() { }

    protected bool IsInvulnerable
    {
        get
        {
            if (Time.time >= lastDamagedTime + minTimeBetDamaged) return false;

            return true;
        }
    }

    // ����ü�� Ȱ��ȭ�ɶ� ���¸� ����
    protected virtual void OnEnable()
    {
        // ������� ���� ���·� ����
        dead = false;
        // ü���� ���� ü������ �ʱ�ȭ
        health = startingHealth;
    }

    // �������� �Դ� ���
    public virtual bool ApplyDamage(DamageMessage damageMessage)
    {
        if (IsInvulnerable || damageMessage.damager == gameObject || dead) return false;

        lastDamagedTime = Time.time;

        // ��������ŭ ü�� ����
        health -= damageMessage.amount;

        // ü���� 0 ���� && ���� ���� �ʾҴٸ� ��� ó�� ����
        if (health <= 0) Die();

        return true;
    }

    // ü���� ȸ���ϴ� ���
    public virtual void RestoreHealth(float newHealth)
    {
        if (dead) return;

        // ü�� �߰�
        health += newHealth;
    }

    // ��� ó��
    public virtual void Die()
    {
        // onDeath �̺�Ʈ�� ��ϵ� �޼��尡 �ִٸ� ����
        if (OnDeath != null) OnDeath();

        // ��� ���¸� ������ ����
        dead = true;
    }
}
