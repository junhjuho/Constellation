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
    public GameObject ExitBtn;
    public GameObject HandMenu;
    public GameObject ReduceBtn;

    bool isTyping = false;
    string[] sentences = {
        "������ �ѷ� ����. ���? ���� ������ ���� ������?\n " +
            "������ �ѱ� �������ִµ� �� ������ ���ڸ� �̾߱Ⱑ ����ִ� �������",
        "�̰��� �� �ִ� ������ ������ �� �� �ִ� ��������.\n ������ �� ������ ���� ���� �� ���� ����� ���̾�",
        "���� ���ϴÿ� �ƹ��͵� ���ٸ� �� �� ������\n"+
        "������ ����, ������ ���⶧���� ���� �����ϰ� ���� �� ���� ���� ������",
        "�̰����� ���� ������� ���ϴ� ���ڸ����� ��� ã�ƺ� �� �ִٳ�!",
        "�׷� ���ݺ��� ��� ������ �� �ִ��� ����� �˷��ְڳ�.\n ���� �޼��� ���ڳ�?",
        "�޼��� ���� ���ڸ��� ������ �� �ְ� �����ִ� �ȳ����� �޷�����.\n �ȳ��ǿ��� �Ϲݱ��� Ŭ���غ���",
        "�Ϲݱ��� Ŭ���ϸ� �ڳװ� �ִ� �ѱ����� �� �� �ִ� ���ڸ����� �ϴ� ���� �������ɼ�",
        "���� �Ϲݱ� ���ڸ����� �̸��� �����ִ� �ȳ����� ���� �ǵ� �ȵ�θ޴��ڸ��� �ѹ� ã�Ƽ� �������ڳ�?\n",
        "�ȵ�θ޴��ڸ��� �������� ���ڸ��� �׸��� ��Ÿ���ٳ�. " +
            "�׸��� ������ �������鼭 �ȵ�θ޴��ڸ��� ��ȭ�� ���� ���� �������ɼ�",
        "���ڸ��� �����ϰ� ���ڸ� ��ȭ�� ���� �� ����!\n " +
            "�׸��� �鸮�� �ٷδ� ���ڸ� ��ȭ�� ���� ü���غ� �� �ִٰ� �ϳ�. �װ� ���Ŭ���� �ڸ�������...",
        "���� �ѹ� ���ϴ� ���ڸ��� �����غ���!",
        "�� ��, ���� ���ڸ��� ��� ź���ߴ��� �ñ��ϴٺ��� ����ǥ�� ��������.\n �׷� �̾߱⸦ ����ְڳ�"
    };

    void OnEnable()
    {
        ReduceBtn.SetActive(false);
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
            if (clickCount > 3)
            {
                HandMenu.SetActive(true);
            }
            if(clickCount > 10)
            {
                ReduceBtn.SetActive(true);
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
            yield return new WaitForSeconds(0.01f);
        }
        isTyping = false;
    }
}