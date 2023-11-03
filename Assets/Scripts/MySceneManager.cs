using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.Loading;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance
    {
        get
        {
            return instance;
        }
    }
    private static MySceneManager instance;
    public CanvasGroup Fade_img;
    float fadeDuration = 2f;
    public GameObject Loading;
    public Text Loading_text;
    bool isChangingScene = false;

    void Start()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    IEnumerator LoadScene(string sceneName)
    {
        Loading.SetActive(true); //�ε� ȭ���� ���

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false; //�ۼ�Ʈ �����̿�

        float past_time = 0;
        float percentage = 0;

        while (!(async.isDone))
        {
            yield return null;

            past_time += Time.deltaTime;

            if (percentage >= 90)
            {
                percentage = Mathf.Lerp(percentage, 100, past_time);

                if (percentage == 100)
                {
                    async.allowSceneActivation = true; //�� ��ȯ �غ� �Ϸ�
                }
            }
            else
            {
                percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
                if (percentage >= 90) past_time = 0;
            }
            Loading_text.text = percentage.ToString("0") + "%"; //�ε� �ۼ�Ʈ ǥ��
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Fade_img.DOFade(0, fadeDuration)
        .OnStart(() => {
            Loading.SetActive(false);
        })
        .OnComplete(() => {
            Fade_img.blocksRaycasts = false;
        });
    }

    public void ChangeScene(string sceneName)
    { /// �ܺο��� ��ȯ�� �� �̸� �ޱ� ///
        if (isChangingScene)
        {
            // �̹� �� ��ȯ ���� ��� �ƹ� �۾��� ���� ����
            return;
        }
        isChangingScene = true;

        Fade_img.DOFade(1, fadeDuration)
        .OnStart(() => {
            Fade_img.blocksRaycasts = true;
        })
        .OnComplete(() => {
            StartCoroutine("LoadScene", sceneName); /// �� �ε� �ڷ�ƾ ���� ///
        });
    }
}
