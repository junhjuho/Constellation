using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcheryHandAnimation : MonoBehaviour {

    private Animator arch_animator;

	void Start ()
    {
        arch_animator = GetComponentInChildren<Animator>();
	}
	

    public void TriggerGrab() => arch_animator.SetTrigger("Grab");
    public void TriggerLet() => arch_animator.SetTrigger("Let");
}
