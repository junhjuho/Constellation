using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public Text dialogText;

    int clickCount = 0;
    public GameObject nextBtn;
    public GameObject prevBtn;
    public GameObject ExitBtn;
    public GameObject ChangeSceneBtn;

    AudioSource audio;
    bool isTyping = false;
    string[] sentences = {
        "� ����! ���� �ø������� 12�� �� �ϳ����� �ŵ��� ���� ���콺��� �ϳ�",
        "���ڶ� �̾��� �� ���� ȯ���Ѵٳ�!",
        "��? ���ڶ� �̾��� �� �ϴ� ���̳ı�? ���� �׷� ����������",
        "���ڶ� �̾��� ���ϴÿ� �� �ִ� ���� ���ڸ��� �����س��� ���� �ö��Ÿ�����̶�� ��",
        "��¥ ���̱� ������ ���� ���� ��ġ�� �����Ա� ������ ���ϴ� ���ڸ����� ã�ƺ� �� �ִٳ�",
        "���� ���ڸ��� ��� ��ȭ �̾߱⵵ �� �� �ְ� ������� �ѱ����� �� �� ���� ���ڸ����� ã�ƺ� �� ����",
        "�׷� ��� �� �� �ֳı�?",
        "��������� �� ����ͺ���!"
    };

    void OnEnable()
    {
        ExitBtn.SetActive(false);
        ChangeSceneBtn.SetActive(false);
        ShowCurrentSentence();
        StartCoroutine(Typing(sentences[clickCount])); // ù ��° ���忡 ���� �ڷ�ƾ ����
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (isTyping)
        {
            // ������ ���� Ÿ���� ���� �� "Next" ��ư�� "Prev" ��ư ��Ȱ��ȭ
            nextBtn.SetActive(false);
            prevBtn.SetActive(false);
        }
        else
        {
            // ������ Ÿ������ ������ �� "Next" ��ư�� "Prev" ��ư Ȱ��ȭ
            nextBtn.SetActive(true);

            if (clickCount > 0)
            {
                prevBtn.SetActive(true);
            }
            else
            {
                prevBtn.SetActive(false);
            }
            if(clickCount > 6)
            {
                nextBtn.SetActive(false);
                ChangeSceneBtn.SetActive(true);
            }
        }
    }

    public void NextBtn()
    {
        if (clickCount < sentences.Length - 1 && !isTyping)
        {
            clickCount++;
            ShowCurrentSentence();
            StartCoroutine(Typing(sentences[clickCount]));
        }
    }

    public void PrevBtn()
    {
        if (clickCount > 0 && !isTyping)
        {
            clickCount--;
            ShowCurrentSentence();
            StartCoroutine(Typing(sentences[clickCount]));
        }
    }

    void ShowCurrentSentence()
    {
        dialogText.text = sentences[clickCount];
    }

    IEnumerator Typing(string text)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogText.text += letter;
            if (audio != null && audio.clip != null)
            {
                audio.PlayOneShot(audio.clip);
            }
            yield return new WaitForSeconds(0.01f);
        }
        isTyping = false;
    }
}