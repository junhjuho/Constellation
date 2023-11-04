using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text dialogText;

    int clickCount = 0;
    public GameObject nextBtn;
    public GameObject prevBtn;
    public GameObject HandMenu;

    AudioSource Typingaudio;

    bool isTyping = false;
    string[] sentences = {
        "������ �ѷ� ����.\n ���? ���� ������ ���� ������?\n ",
            "���� �ѱ� �������ִµ� �� ������ ���ڸ� �̾߱Ⱑ ����ִ� �����",
        "�̰��� ���ϴ� ���ڸ����� ��� ã�ƺ� �� �ִ� ������!",
        "�׷� ���ݺ��� ��� �� �� �ִ��� ����� �˷��ְڳ�.\n �ȳ����� �ѹ� ���Գ�!",
        "�ȳ����� �̿��ϸ� ���ݱ�, �Ϲݱ��� ���ڸ����� �� �� �־�.\n �켱 �ȳ��ǿ��� �Ϲݱ��� Ŭ���غ���",
        "�Ϲݱ��� Ŭ���ϸ� �ڳװ� �ִ� �ѱ����� �� �� �ִ� ���ڸ����� �ϴ� ���� �������ɼ�",
        "���� �Ϲݱ� ���ڸ����� �̸��� �����ִµ� �װ����� �ȵ�θ޴��ڸ��� �ѹ� ã�Ƽ� �������ڳ�?\n",
        "�ȵ�θ޴��ڸ��� �������� ���ڸ��� �׸��� ��Ÿ���ٳ�.\n �ȳ��� �� ȭ��ǥ�� ���󰡸� �ش� ���ڸ��� �� �� ����",
            "�׸��� ���� �������鼭 �ȵ�θ޴��ڸ��� ��ȭ �̾߱⸦ ���� �� �ִٳ�\n" + 
        "���ڸ��� �����ϰ� ���ڸ� ��ȭ�� ���� �� ����!",
            "�ȳ��� ���ʿ� '����'�� ������ �ٴ��� ������ٳ�.\n �ٴ��� ������� �� �� ������ �ݴ��� �ϴ��� �ٶ� �� �ִٱ�!",
            "�׸��� �鸮�� �ٷδ� ���ڸ� ��ȭ�� ���� ü���غ� �� �ִٰ� �ϴ��� �װ� ���Ŭ���� �ڸ�������...",
        "�ñ��ϸ� ���Ŭ���� ���ڸ��� ã�� �������Գ�!\n ���� �ѹ� ���ϴ� ���ڸ��� �����غ���!"
    };

    void OnEnable()
    {
        ShowCurrentSentence();
        StartCoroutine(Typing(sentences[clickCount])); // ù ��° ���忡 ���� �ڷ�ƾ ����
    }

    void Start()
    {
        Typingaudio = GetComponent<AudioSource>();    
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
            if (clickCount > 3)
            {
                HandMenu.SetActive(true);
            }
            if(clickCount > 10)
            {
                nextBtn.SetActive(false);
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
            Debug.Log(clickCount);
        }
    }

    public void PrevBtn()
    {
        if (clickCount > 0 && !isTyping)
        {
            clickCount--;
            ShowCurrentSentence();
            StartCoroutine(Typing(sentences[clickCount]));
            Debug.Log(clickCount);
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
            if (Typingaudio != null && Typingaudio.clip != null)
            {
                Typingaudio.PlayOneShot(Typingaudio.clip);
            }
            yield return new WaitForSeconds(0.04f);
        }
        isTyping = false;
    }
}
