using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : WeaponController
{
    public float radius = 2.0f; // ���� ������ �ݰ� ����
    RaycastHit[] hitInfos = new RaycastHit[10]; // ���� ��� �ִ� 10���� �浹�� ������ �� ����

    public override void WeaponRay()
    {
        // �ӵ��� 5.5 �ʰ��� ��� SphereCast ����
        if ((transform.position - prevPos).magnitude / Time.deltaTime > 1f)
        {
            float currentSpeed = (transform.position - prevPos).magnitude / Time.deltaTime;
            adjustDamage = damage * currentSpeed;

            // �浹 ������ ������ �迭 �غ�
            
            int hitCount = Physics.SphereCastNonAlloc(attackRoot.position, radius, transform.up, hitInfos, WeaponLenth, layer);

            for (int i = 0; i < hitCount; i++)
            {
                RaycastHit hitInfo = hitInfos[i];
                var attackTargetEntity = hitInfo.collider.GetComponent<CreatureController>();

                if (attackTargetEntity != null && !lastAttackedTargets.Contains(attackTargetEntity))
                {
                    var message = new DamageMessage();
                    Debug.Log(adjustDamage);
                    message.amount = adjustDamage; // ������ �� ����
                    message.damager = gameObject; // �������� ���� ��ü ����
                    message.hitPoint = hitInfo.point; // �浹 ��ġ
                    message.hitNormal = attackRoot.TransformDirection(hitInfo.normal); // �浹�� ǥ���� ��� ����
                    Manager.Haptic.Haptic(transform); // ���� ȿ��
                    HitCreatureEffect(); // ũ��ó�� ��Ʈ ȿ��

                    attackTargetEntity.ApplyDamage(message); // ������ ����
                    lastAttackedTargets.Add(attackTargetEntity); // ������ ��� ��Ͽ� �߰�
                    StartCoroutine(AccessInfoAfterDelay());

                    // �ϳ��� Ÿ�ٿ� ��Ʈ�� �� �ٷ� ������ ������ ������, ���� ����� ó���� ������ ���� �ʿ�
                    // break; // ���⿡ break�� ���� ��� ù ��° �浹�� ���ؼ��� ó��
                }
            }

            // ���� ��ġ ������Ʈ
            prevPos = transform.position;
        }
    }

    public override void HitCreatureEffect()
    {
        if (audioSource == null)
        {
            Debug.Log("audioSource is null");
        }
        audioSource.PlayOneShot(hitClip);
    }

#if UNITY_EDITOR
    protected override void OnDrawGizmosSelected()
    {
        if (attackRoot != null)
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
            // ���� ��� ��ü�� �׷��� SphereCast�� �ð�ȭ�մϴ�.
            Vector3 direction = transform.up * WeaponLenth;
            Vector3 endPoint = attackRoot.position + direction;

            // ��ü�� ���� �κ��� �׸��ϴ�.
            Gizmos.DrawWireSphere(attackRoot.position, radius);
            // ��ü�� �� �κ��� �׸��ϴ�.
            Gizmos.DrawWireSphere(endPoint, radius);
            // ��ü�� ��θ� �׸��ϴ�.
            Gizmos.DrawLine(attackRoot.position, endPoint);
        }
    }
#endif
}