using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    static Manager s_instance;
    static Manager Instance { get { Init(); return s_instance; } }

    #region Core
    HapticController _haptic = new HapticController();


    public static HapticController haptic { get { return Instance._haptic; } }

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

            DontDestroyOnLoad(go);//���� �ٲ� �ı����� �ʰ�
            s_instance = go.GetComponent<Manager>();//�ν��ӽ��� �Ŵ��� ����

            /*s_instance._data.Init();
            s_instance._pool.Init();
            s_instance._sound.Init();*/
        }
    }
    public static void Clear()
    {
        /*Scene.Clear();*/
    }
}
