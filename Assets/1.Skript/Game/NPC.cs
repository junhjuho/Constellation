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

    void Start()
    {
        if (talkBox != null)
        {
            talkBox.SetActive(false);

        }
        Invoke("Talk1", 1.5f);
    }

    public void Talk1()
    {
        talkBox.SetActive(true);
        Invoke("Talk2", delay);
    }

    public void Talk2()
    {
        talkText.text = " �켱 ������ ���� �����Գ�";
        Invoke("Talk3", delay);
    }

    public void Talk3()
    {
        talkText.text = " ������ ���� �������� ���⸦ ã��";
        Invoke("Talk4", delay);
    }

    public void Talk4()
    {
        talkText.text = "�Ƹ����� ��������� ���� ���� ���� �����״�";
        Invoke("Disapear", delay);
    }

    public void Disapear()
    {
        Instantiate(effect, transform.position + new Vector3(0, 1.0f, 0), Quaternion.Euler(0, 90, 0));
        gameObject.SetActive(false);
    }
}