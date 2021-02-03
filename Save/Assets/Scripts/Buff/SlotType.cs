using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public buffSlot currentSlot;
    public Transform buttonScale;
    Vector3 defaultScale;
    public GameObject buffUI;
    public Buff buff; //건드리지 말 것
    public TalkManager talkManager; //건드리지 말것
    public int slotNum;
    public GameObject choosenBuffUI;
    public ChoosenBuff choosenBuff;
    [SerializeField]
    private Text buffContext; //커서 감지 시 카드 설명 출력
    public GameObject contextBg;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
        contextBg.SetActive(false);
    }

    //버프카드 클릭(선택) 시
    public void OnButtonClick()
    {
        GetSlotNum();
        talkManager.isBuff = false; //버프선택 다시 못하게 하기
        choosenBuff.ChooseBuff(slotNum); //슬롯 넘버(인덱스 값) 넘겨주기
        buffUI.SetActive(false); //버프 선택 창 끄기
        choosenBuffUI.SetActive(true); //선택된 버프 창 켜기
    }

    //버프카드 위에 커서 닿을 시
    public void OnPointerEnter(PointerEventData eventData) //스크립트가 붙어있는 오브젝트에 마우스가 닿으면 이 함수가 호출됨
    {
        buttonScale.localScale = defaultScale * 1.03f; //크기 조절
        GetSlotNum();
        buffContext.text = buff.mySelectBuff[slotNum].myBuffContext; //설명 텍스트 띄우기
        contextBg.SetActive(true); //설명 텍스트 뒤 배경 띄우기
    }

    //버프카드 위 커서 제거 시
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
        buffContext.text = null;
        contextBg.SetActive(false);
    }

    //슬롯 넘버를 받아오는 함수
    public void GetSlotNum() 
    {
        switch (currentSlot)
        {
            case buffSlot.BuffSlot1:
                slotNum = 0;
                break;
            case buffSlot.BuffSlot2:
                slotNum = 1;
                break;
            case buffSlot.BuffSlot3:
                slotNum = 4;
                break;
        }
    }
}
