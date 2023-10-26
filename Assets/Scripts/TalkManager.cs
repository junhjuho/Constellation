using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(100, new string[] { "안녕?", "이 곳에 처음 왔구나?" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }

}
