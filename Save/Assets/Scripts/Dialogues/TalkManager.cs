using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    public GameObject buffUI;
    public GameManager gameManager;

    public bool isBuff = true;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();

        talkData = new Dictionary<int, string[]>();
        GenerateData();
        buffUI.SetActive(false); //버프UI 꺼두기

        //isBuff = true;
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "안녕?", "이 곳에 처음 왔구나?", "버프를 선택하렴" }); //숲에서 만나는 NPC
        talkData.Add(1001, new string[] { "안녕?", "오랜만이구나", "이번에도 버프를 선택하렴" }); //황무지에서 만나는 NPC
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length && isBuff == true) //대화가 끝났고 버프선택이 가능하면
        {
            buffUI.SetActive(true); //버프UI 켜주기 
            return null;
        }
        else if(talkIndex == talkData[id].Length && isBuff == false) //대화가 끝났고 버프선택이 불가능하면
        {
            return null;
        }
        else //대화가 끝나지 않았으면
        {
            return talkData[id][talkIndex];
        }
    }
}