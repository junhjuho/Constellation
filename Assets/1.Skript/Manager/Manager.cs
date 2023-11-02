using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    static Manager s_instance;
    static public Manager Instance { get { Init(); return s_instance; } }

    bool isGameOver = false;

    public Text textBox;


    #region Core
    HapticController _haptic = new HapticController();


    public static HapticController Haptic { get { return Instance._haptic; } }


    #endregion

    void Start()
    {
        Init();
    }

    static void Init()//�Ŵ��� �ʱ�ȭ
    {
        if (s_instance == null)//�ν��Ͻ��� �������� ������
        {
            GameObject go = GameObject.Find("@Managers"); //���̶�Űâ���� �Ŵ����� ã��
            if (go == null)//�� ã����
            {
                go = new GameObject { name = "@Managers" }; // �Ŵ��� ������Ʈ�� �����
                go.AddComponent<Manager>();//�Ŵ��� ��ũ��Ʈ�� �߰���
            }

            s_instance = go.GetComponent<Manager>();//�ν��ӽ��� �Ŵ��� ����
        }
    }
    public static void Clear()
    {
        /*Scene.Clear();*/
    }

    public void HomeScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ObserveSecne()
    {
        SceneManager.LoadScene(1);
    }

    public void ReLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
        }
    }

}
