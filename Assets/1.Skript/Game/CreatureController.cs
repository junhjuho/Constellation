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

    public float startingHealth = 100f; // 시작 체력
    public float health { get; protected set; } // 현재 체력
    public bool dead { get; protected set; } // 사망 상태

    public event Action OnDeath; // 사망시 발동할 이벤트

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

    // 생명체가 활성화될때 상태를 리셋
    protected virtual void OnEnable()
    {
        // 사망하지 않은 상태로 시작
        dead = false;
        // 체력을 시작 체력으로 초기화
        health = startingHealth;
    }

    // 데미지를 입는 기능
    public virtual bool ApplyDamage(DamageMessage damageMessage)
    {
        if (IsInvulnerable || damageMessage.damager == gameObject || dead) return false;

        lastDamagedTime = Time.time;

        // 데미지만큼 체력 감소
        health -= damageMessage.amount;

        // 체력이 0 이하 && 아직 죽지 않았다면 사망 처리 실행
        if (health <= 0) Die();

        return true;
    }

    // 체력을 회복하는 기능
    public virtual void RestoreHealth(float newHealth)
    {
        if (dead) return;

        // 체력 추가
        health += newHealth;
    }

    // 사망 처리
    public virtual void Die()
    {
        // onDeath 이벤트에 등록된 메서드가 있다면 실행
        if (OnDeath != null) OnDeath();

        // 사망 상태를 참으로 변경
        dead = true;
    }
}
