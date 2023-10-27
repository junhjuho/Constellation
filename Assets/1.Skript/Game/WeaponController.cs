using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class WeaponController : MonoBehaviour
{
    public LayerMask layer;
    public float baseDamage = 10f; // �⺻ ������
    public float distanceMultiplier = 2f; // �Ÿ��� ���� ������ ����

    float adjustedDamage = 30f;
    public AudioClip hitAudio;
    AudioSource audioSource;
    private HapticController hapticController;

    Vector3 prevPos;


    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        hapticController = GetComponent<HapticController>();
    }


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other} in");
       
        if (other.tag == "Monster")
        {
            HitMonster(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other} out");
    }

    public void HitMonster(Collider other)
    {

        Monster monster = other.gameObject.GetComponentInParent<Monster>();

        if (monster != null) // Monster ������Ʈ�� �ִ��� Ȯ��
        {
            monster.TakeDamage(adjustedDamage, other);
            hapticController.Haptic(transform);
            HitCreatureEffect();
            Debug.Log("monster Entered!");
        }
        else
        {
            Debug.Log($"{other}Componentis null");
        }
    }

    public void HitCreatureEffect()
    {
        Debug.Log("����");
        if(audioSource == null)
        {
            Debug.Log("audioSource is null");
        }

        audioSource.pitch = 1.5f;
        audioSource.PlayOneShot(hitAudio);
    }
}
