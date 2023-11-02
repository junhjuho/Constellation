using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class WeaponController : MonoBehaviour
{
    public LayerMask layer;
    public float damage = 10f; // �⺻ ������
    public float adjustDamage = 10f; // �⺻ ������
    public float distanceMultiplier = 2f; // �Ÿ��� ���� ������ ����
    public Transform attackRoot;
    public float WeaponLenth;

    Rigidbody rb;
    public AudioClip hitClip;
    public AudioClip swingClip;
    TrailRenderer trailRenderer;
    AudioSource audioSource;
    private RaycastHit[] hits = new RaycastHit[10];

    private List<CreatureController> lastAttackedTargets = new List<CreatureController>();

    Vector3 prevPos;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        audioSource.pitch = 1.5f;
    }

    private void Update()
    {
        SwordRay();
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        if (attackRoot != null)
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
            Gizmos.DrawRay(attackRoot.position, transform.up * WeaponLenth);
        }
    }

#endif

    public void HitCreatureEffect()
    {
        if (audioSource == null)
        {
            Debug.Log("audioSource is null");
        }
        audioSource.PlayOneShot(hitClip);
    }


    IEnumerator AccessInfoAfterDelay()
    {
        yield return new WaitForSeconds(0.6f);
        lastAttackedTargets.Clear();
    }

    void SwordRay()
    {
        float currentSpeed = (transform.position - prevPos).magnitude / Time.deltaTime;

        if (currentSpeed > 5.5f)
        {
            trailRenderer.enabled = true;
            adjustDamage = damage * currentSpeed;
            
            // RaycastNonAlloc ȣ��� ����
            int hitCount = Physics.RaycastNonAlloc(attackRoot.position, transform.up, hits, WeaponLenth, layer);

            for (int i = 0; i < hitCount; i++)
            {
                var hit = hits[i]; // �迭���� hit ������ ������
                var attackTargetEntity = hit.collider.GetComponent<CreatureController>();

                if (attackTargetEntity != null && !lastAttackedTargets.Contains(attackTargetEntity))
                {
                    var message = new DamageMessage();
                    message.amount = adjustDamage;
                    Debug.Log(adjustDamage);
                    message.damager = gameObject;
                    message.hitPoint = hit.point;
                    message.hitNormal = attackRoot.TransformDirection(hit.normal);
                    Manager.Haptic.Haptic(transform);
                    audioSource.PlayOneShot(swingClip);
                    HitCreatureEffect();

                    attackTargetEntity.ApplyDamage(message);
                    lastAttackedTargets.Add(attackTargetEntity);

                    StartCoroutine(AccessInfoAfterDelay());
                    // �ϳ��� Ÿ�ٿ� ��Ʈ�� �� �ٷ� ������ ����
                    break;
                }
            }

            /*RaycastHit hit;

            if (Physics.Raycast(attackRoot.position, transform.up, out hit, WeaponLenth, layer))
            {
                var attackTargetEntity = hit.collider.GetComponent<CreatureController>();

                if (attackTargetEntity != null && !lastAttackedTargets.Contains(attackTargetEntity))
                {
                    var message = new DamageMessage();
                    message.amount = adjustDamage;
                    Debug.Log(adjustDamage);
                    message.damager = gameObject;
                    message.hitPoint = hit.point;
                    message.hitNormal = attackRoot.TransformDirection(hit.normal);
                    audioSource.PlayOneShot(swingClip);
                    Manager.Haptic.Haptic(transform);
                    HitCreatureEffect();

                    attackTargetEntity.ApplyDamage(message);
                    lastAttackedTargets.Add(attackTargetEntity);

                    StartCoroutine(AccessInfoAfterDelay());
                }
            }*/
        }
        else
        {
            trailRenderer.enabled = false;
        }

        prevPos = transform.position;
    }

}
