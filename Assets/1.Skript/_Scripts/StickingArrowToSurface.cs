using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Experimental.GraphView.GraphView;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class StickingArrowToSurface : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private SphereCollider myCollider;
    [SerializeField] private GameObject stickingArrow;

    public LayerMask layer;
    public Transform attackRoot;
    public float WeaponLenth;
    public float damage;

    public AudioClip hitAudio;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    /*private void Update()
    {
        ArrowAttack();
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        myCollider.isTrigger = true;

        GameObject arrow = Instantiate(stickingArrow);
        arrow.transform.position = transform.position;
        arrow.transform.forward = transform.forward;
        Manager.haptic.VibrateBothControllers(HapticController.objectStrength, HapticController.objectDuration);

        if (collision.collider.attachedRigidbody != null)
        {
            arrow.transform.parent = collision.collider.attachedRigidbody.transform;
            var attackTargetEntity = collision.collider.GetComponent<CreatureController>();

            if (attackTargetEntity != null)
            {
                var message = new DamageMessage();
                message.amount = damage;
                message.damager = gameObject;
                message.hitPoint = collision.contacts[0].point;
                message.hitNormal = attackRoot.TransformDirection(collision.contacts[0].normal);
                Manager.haptic.VibrateBothControllers(HapticController.targerSterngth, HapticController.targerDuration);
                HitCreatureEffect();

                attackTargetEntity.ApplyDamage(message);

            }
        }

        Destroy(gameObject);
        Destroy(arrow, 5.0f);
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        if (attackRoot != null)
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
            Gizmos.DrawRay(attackRoot.position, transform.forward * WeaponLenth);
        }
    }

#endif

  /*  public void ArrowAttack()
    {
        RaycastHit hit;

        if (Physics.Raycast(attackRoot.position, transform.forward, out hit, WeaponLenth, layer))
        {
            var attackTargetEntity = hit.collider.GetComponent<CreatureController>();
            Debug.Log(attackTargetEntity.gameObject.name);

            if (attackTargetEntity != null)
            {
                var message = new DamageMessage();
                message.amount = damage; 
                message.damager = gameObject;
                message.hitPoint = hit.point;
                message.hitNormal = attackRoot.TransformDirection(hit.normal);
                hapticController.VibrateBothControllers();
                HitCreatureEffect();

                attackTargetEntity.ApplyDamage(message);

            }
        }
    }*/

    public void HitCreatureEffect()
    {
        if (audioSource == null)
        {
            Debug.Log("audioSource is null");
        }

        audioSource.pitch = 1.5f;
        audioSource.PlayOneShot(hitAudio);
    }
}

