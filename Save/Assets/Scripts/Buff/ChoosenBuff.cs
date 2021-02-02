using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosenBuff : MonoBehaviour
{
    public Buff buff;
    public Image choosenBuffImage;//사용자가 선택한 버프 이미지 저장할 변수
    public HpBar hpBar;
    public GameManager gameManager;

    public void ChooseBuff(int indexNum)
    {
        //사용자가 고른 버프 카드의 이미지를 출력
        choosenBuffImage.sprite = buff.mySelectBuff[indexNum].mySprite;

        //버프 카드 선택시 각각 스탯 증가(버프 적용)
        hpBar.playerHp += buff.mySelectBuff[indexNum].myHpBuff;
        gameManager.dashCool += buff.mySelectBuff[indexNum].myDashCoolBuff; //값이 다 0으로 되어있네
        gameManager.fireCool += buff.mySelectBuff[indexNum].myFireBallCoolBuff;
        gameManager.rhythmCool += buff.mySelectBuff[indexNum].myRhythmCoolBuff;
    }
}
