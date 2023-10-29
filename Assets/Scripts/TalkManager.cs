using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text dialogText;
    int clickCount = 0;
    public GameObject nextBtn;
    public GameObject prevBtn;
    public GameObject ExitBtn;

    bool isTyping = false;
    string[] sentences = {
        "Hello, nice to meet you! I'm Zeus, the 12 gods of Olympus and the king of the gods! Welcome to stellamyth",
        "This is the second timedfewaf",
        "This is the third timeggg",
        "It's the fourth time"
    };
    void OnEnable()
    {
        ExitBtn.SetActive(false);
        ShowCurrentSentence();
        StartCoroutine(Typing(sentences[clickCount])); // ù ��° ���忡 ���� �ڷ�ƾ ����
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
            yield return new WaitForSeconds(0.01f);
        }
        isTyping = false;
    }
}