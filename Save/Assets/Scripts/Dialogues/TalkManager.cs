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
        //숲에서 만나는 NPC
        talkData.Add(1000, new string[] { "자네가 이 곳의 변종된 괴물들을 물리치러 온 기사인건가?", "반갑네, 이 일을 의뢰한 음...그냥 지나가던 노인이라고 생각하게나.", 
            "지금 앞에 보이는 숲에 변종 괴물들이 많아 어려움을 겪고있다고하여 자네에게 괴물들의 처치를 의뢰하게 되었다네.", 
            "혹시 이 카드 중 한 장을 뽑아보겠는가?", "내가 많은 도움은 못되겠지만 이 카드는 자네에게 도움이 많이 될 걸세." });

        //황무지에서 만나는 NPC
        talkData.Add(1001, new string[] { "숲의 변종 괴물들을 처리해줘서 너무 고맙네!", "이제 사람들이 숲을 편하게 다닐 수 있게 되었다네.", 
            "이 곳 황무지는 숲보다 변종 괴물들이 더 많다네." + System.Environment.NewLine + "괴물 처치를 한 번 더 부탁해도 되겠나?", 
            "...뭐?" + System.Environment.NewLine + "누군가가 귓가에 속삭인다고?", "흠...", "매우 소름끼치는 일이군",
            "혹시 저주받은 신전이라고 알고있나?", "그 쪽에서 미스테리한 일들이 자주 발생한다고 하네", "자네에게 속삭이는 누군가가 그 신전 안에 있을 지도 모르지",
            "아님 그냥 자네가 미친걸 수도 있고 말이야",
            "대화는 이쯤 하고 카드를 한 장 뽑으시게나.", "괴물들 처리에 도움이 많이 될 테니." });

        //저주받은 신전에서 만나는 최종 보스
        talkData.Add(2000, new string[] { "너...", "용케 여기까지 왔구나", "날 찾아와서 본 소감이 어떠한가?", "무섭나? 두렵나?", 
        "걱정 마라" + System.Environment.NewLine + "너에게 해를 끼치진 않으니", "그저...", "나의 마지막을 봐 줄 수 있겠나?",
        "혼자 마지막 밤을 보내는 건 슬프잖아", "네가 내 옆에 있다면...", "난 편히 갈 수 있을거야", "내 옆에 있다면...",
        "네가 날 대신할 수 있을테니까", "..."}); 
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