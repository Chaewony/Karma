using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff : MonoBehaviour
{
    [SerializeField]
    private List<BuffInfo> allBuff = new List<BuffInfo>();
    [SerializeField]
    private GameObject buffUI;
    [SerializeField]
    private Text[] buffNames;//빈 텍스트 리스트 생성
    private List<BuffInfo> selectBuff = new List<BuffInfo>();
    [SerializeField]
    private Image[] buffImages; //빈 이미지 리스트 생성, 스프라이트로 하면 안되는거 확인함

    public List<BuffInfo> mySelectBuff { get => selectBuff; }

    /*public string choosenBuff;//사용자가 선택한 버프 이름 저장할 변수
    public Sprite choosenBuffImage;//사용자가 선택한 버프 이미지 저장할 변수*/


    private void Start()
    {
        ShowBuff();
    }

    //////////////////////////////////////////////////////////////////////////////////////////
    public void ShowBuff()
    {
        for (int i = 0; i < 5;)
        {
            int rand = Random.Range(0, allBuff.Count);
            if (!selectBuff.Contains(allBuff[rand]) || selectBuff.Count == 0)
            {
                selectBuff.Add(allBuff[rand]);
                i++;
            }
        }

        for (int i = 0; i < selectBuff.Count; i++)
        {
            buffNames[i].text = selectBuff[i].myBuffName; //슬롯UI에 (선택된)텍스트 할당
            buffImages[i].sprite = selectBuff[i].mySprite; //슬롯UI에 (선택된)이미지 할당 
        }
    }

    /*public void ChooseBuff(int indexNum)
    {
        choosenBuff = selectBuff[indexNum].myBuffName; //사용자가 고른 버프 이름 저장
        choosenBuffImage = selectBuff[indexNum].mySprite; //사용자가 고른 버프 이미지 저장
        Debug.Log(choosenBuff); //사용자가 고른 버프 이름 출력
    }*/
}
