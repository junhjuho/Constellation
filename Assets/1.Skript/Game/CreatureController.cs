using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureController : MonoBehaviour
{

    [SerializeField]
    protected Vector3 _destPos;

    [SerializeField]
    protected State _state = State.Idle;

    [SerializeField]
    protected GameObject _lockTarget;

    protected Animator anim;

    private void Start()
    {
        Init();
    }

    public enum State
    {
        Idle,
        Moving,
        Attack,
        Damaged,
        Die,
    }

    public virtual State state
    {
        get { return _state; }
        set
        {
            _state = value;

            
            switch (_state)
            {
                case State.Die:
                    anim.CrossFade("Death", 0.1f);
                    break;
                case State.Idle:
                    anim.CrossFade("Idle", 0.1f);
                    break;
                case State.Moving:
                    anim.CrossFade("Run", 0.05f);

                    break;
                case State.Attack:

                    break;
                case State.Damaged:
                    
                    break;

            }
        }
    }


    public void Update()
    {
        switch (state)
        {
            case State.Die:
                UpdateDie();
                break;

            case State.Moving:
                UpdateMoving();
                break;

            case State.Idle:
                UpdateIdle();
                break;

            case State.Attack:
                UpdateAttack();
                break;

            case State.Damaged:
                UpdateDamaged();
                break;
        }
    }

    public abstract void Init();
    protected virtual void UpdateDie() { }
    protected virtual void UpdateMoving() { }
    protected virtual void UpdateIdle() { }
    protected virtual void UpdateAttack() { }
    protected virtual void UpdateDamaged() { }
}
