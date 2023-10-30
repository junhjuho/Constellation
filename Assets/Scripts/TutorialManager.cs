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
    public GameObject DesBtn;


    bool isTyping = false;
    string[] sentences = {
        "주위를 둘러 보게. 어떤가? 별이 굉장히 많지 않은가?\n " +
            "고서도 한권 놓여져있는데 그 곳에는 별자리 이야기가 담겨있는 고서라네",
        "이곳에 떠 있는 별들은 실제로 볼 수 있는 별들이지.\n 하지만 두 눈으로 직접 보는 건 아주 어려운 일이야",
        "만약 밤하늘에 아무것도 없다면 볼 수 있지만\n"+
        "날씨나 구름, 기후의 영향때문에 별을 깨끗하게 보는 건 정말 힘든 일이지",
        "이곳에선 날씨 상관없이 원하는 별자리들을 모두 찾아볼 수 있다네!",
        "그럼 지금부터 어떻게 관찰할 수 있는지 방법을 알려주겠네.\n 먼저 왼손을 들어보겠나?",
        "왼손을 보면 별자리를 관찰할 수 있게 도와주는 안내판이 달려있지.\n 안내판에서 북반구를 클릭해보게",
        "북반구를 클릭하면 자네가 있는 한국에서 볼 수 있는 별자리들이 하늘 위에 떠있을걸세",
        "또한 북반구 별자리들의 이름이 적혀있는 안내판이 나올 건데 안드로메다자리를 한번 찾아서 눌러보겠나?\n",
        "안드로메다자리를 눌러보면 별자리의 그림이 나타난다네. " +
            "그리고 고서가 펼쳐지면서 안드로메다자리의 신화가 적힌 장이 펼쳐질걸세",
        "별자리도 관찰하고 별자리 신화도 읽을 수 있지!\n " +
            "그리고 들리는 바로는 별자리 신화를 직접 체험해볼 수 있다고 하네. 그게 헤라클레스 자리였던가...",
        "이제 한번 원하는 별자리를 관찰해보게!",
        "아 참, 만약 별자리가 어떻게 탄생했는지 궁금하다보면 물음표를 눌러보게.\n 그럼 이야기를 들려주겠네"
    };

    void OnEnable()
    {
        ReduceBtn.SetActive(false);
        ExitBtn.SetActive(false);
        ShowCurrentSentence();
        StartCoroutine(Typing(sentences[clickCount])); // 첫 번째 문장에 대한 코루틴 시작
    }

    void Update()
    {
        if (isTyping)
        {
            // 문장이 아직 타이핑 중일 때 "Next" 버튼와 "Prev" 버튼 비활성화
            nextBtn.SetActive(false);
            prevBtn.SetActive(false);
        }
        else
        {
            // 문장이 타이핑이 끝났을 때 "Next" 버튼와 "Prev" 버튼 활성화
            nextBtn.SetActive(true);

            if (clickCount > 0)
            {
                prevBtn.SetActive(true);
            }
            else
            {
                prevBtn.SetActive(false);
            }
            if (clickCount > 5)
            {
                HandMenu.SetActive(true);
            }
            if(clickCount > 11)
            {
                ReduceBtn.SetActive(true);
                nextBtn.SetActive(false);
                DesBtn.SetActive(true);
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
