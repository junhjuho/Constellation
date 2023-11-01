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

    static void Init()//매니저 초기화
    {
        if (s_instance == null)//인스턴스가 존재하지 않으면
        {
            GameObject go = GameObject.Find("@Managers"); //하이라키창에서 매니저를 찾음
            if (go == null)//못 찾으면
            {
                go = new GameObject { name = "@Managers" }; // 매니저 오브젝트를 만들고
                go.AddComponent<Manager>();//매니저 스크립트를 추가함
            }

            DontDestroyOnLoad(go);//씬이 바뀌어도 파괴하지 않고
            s_instance = go.GetComponent<Manager>();//인스텁스는 매니저 대입

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
