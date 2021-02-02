using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnButtonClick()
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
        talkManager.isBuff = false; //버프선택 다시 못하게 하기
        choosenBuff.ChooseBuff(slotNum); //슬롯 넘버(인덱스 값) 넘겨주기
        buffUI.SetActive(false); //버프 선택 창 끄기
        choosenBuffUI.SetActive(true); //선택된 버프 창 켜기
    }

    public void OnPointerEnter(PointerEventData eventData) //스크립트가 붙어있는 오브젝트에 마우스가 닿으면 이 함수가 호출됨
    {
        buttonScale.localScale = defaultScale * 1.03f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
