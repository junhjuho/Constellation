using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

[System.Serializable]
public class AnimationInput
{
    public string animationPropertyName;
    public InputActionProperty action;
}

public class AnimationController : MonoBehaviour
{

    [SerializeField] private InputActionReference move;
    public int _hp = 100;

    public List<AnimationInput> animationInputs;
    private Animator anim;
    bool isDead = false;
    RigBuilder rigBuilder;
    LowerBodyAnimation lowerBodyAnimation;
    Rigidbody rigidBody;


    private void Start()
    {
        anim = GetComponent<Animator>();
        rigBuilder = GetComponent<RigBuilder>();
        move.action.started += AnimateLegs;
        move.action.canceled += StopAnimation;
        lowerBodyAnimation = GetComponent<LowerBodyAnimation>();
        rigidBody = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        Die();
        foreach (var item in animationInputs)
        {
            float actionValue = item.action.action.ReadValue<float>();
            anim.SetFloat(item.animationPropertyName, actionValue);
        }
    }

    private void AnimateLegs(InputAction.CallbackContext obj)
    {
        bool isMovingForward = move.action.ReadValue<Vector2>().y > 0;
        //Debug.Log("AnimateLegs On");
        if (anim != null)
        {
            if (isMovingForward)
            {
                //Debug.Log("isWalking True");
                anim.SetBool("isWalking", true);
                anim.SetFloat("animSpeed", 2f);
            }
            else
            {
                //Debug.Log("isWalking false");
                anim.SetBool("isWalking", true);
                anim.SetFloat("animSpeed", -2f);
            }
        }
       
    }

    private void StopAnimation(InputAction.CallbackContext obj)
    {
        if (anim != null)
        {
            //Debug.Log("Stop");
            anim.SetBool("isWalking", false);
            anim.SetFloat("animSpeed", 0);
        }
    }

    public void Die()
    {

        if (_hp <= 0 && !isDead)
        {
            isDead = true;
            lowerBodyAnimation.enabled = false;
            rigBuilder.enabled = false;
            anim.SetTrigger("isDead");
        }
    }
}
