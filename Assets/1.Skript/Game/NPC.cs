using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject talkBox;
    public GameObject effect;
    public Text talkText;
    public float delay = 2.5f;

    AudioSource audioSource;

    void Start()
    {
        if (talkBox != null)
        {
            talkBox.SetActive(false);

        }
        Invoke("Talk1", 5f);
        audioSource = GetComponent<AudioSource>();
    }

    public void Talk1()
    {
        talkBox.SetActive(true);
        Invoke("Talk2", delay);
        audioSource.Play();
    }

    public void Talk2()
    {
        talkText.text = " ��񺴵��� ���� ������ �켱 ������ ���� �����Գ�";
        Invoke("Talk3", delay);
        audioSource.Play();
    }

    public void Talk3()
    {
        talkText.text = " ������ ���� �������� ���⸦ ã��";
        Invoke("Talk4", delay);
        audioSource.Play();
    }

    public void Talk4()
    {
        talkText.text = "�Ƹ����� ������� ���� ���� ���� �����״�";
        Invoke("Disapear", delay);
        audioSource.Play();
    }

    public void Disapear()
    {
        Instantiate(effect, transform.position + new Vector3(0, 1.0f, 0), Quaternion.Euler(0, 90, 0));
        gameObject.SetActive(false);
    }
}