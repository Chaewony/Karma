using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public TalkManager talkManager;
    public int talkIndex;
    public GameObject choosenBuff;

    //스킬 쿨타임 관련
    public PlayerAttack playerAttack; //이 스크립트에서 쿨타임 적용
   
    public Image dashCoolImg; //대쉬 쿨타임 이미지
    public float dashCool; //대쉬 쿨타임

    public Image fireCoolImg; //파이어볼 쿨타임 이미지
    public float fireCool; //파이어볼 쿨타임

    public Image rhythmCoolImg; //리듬입력 쿨타임 이미지
    public float rhythmCool; //리듬입력 쿨타임

    WaitForSeconds seconds = new WaitForSeconds(0.1f);

    //씬 로드 관련
    public int deathCount;
    public int enemiesCount;
    public FadeEffect fadeEffect;
    public bool isForestBossDead = false;
    public bool isDessertBossDead = false;
    public bool isEnding = false;
    //public GameObject forestBoss;

    public void Awake()
    {
        choosenBuff.SetActive(false); //선택된 버프창 꺼두기
        //forestBoss.gameObject.SetActive(false);
    }

    public void Update()
    {    
        dialogueUI.SetActive(isAction);

        //씬 로드 관련
        if (isForestBossDead) //숲 보스 죽음
        {
            fadeEffect.StartCoroutine(fadeEffect.Fade(0, 1));//페이드 아웃
            Invoke("LoadDessert", 5);
        }
        /*if (enemiesCount==11 && deathCount >= enemiesCount)
        {
            //forestBoss.gameObject.SetActive(true);
            if(isForestBossDead)
            {
                fadeEffect.StartCoroutine(fadeEffect.Fade(0, 1));//페이드 아웃
                Invoke("LoadDessert", 5);
            }
        }*/
        if (isDessertBossDead) //황무지 보스 죽음
        {
            fadeEffect.StartCoroutine(fadeEffect.Fade(0, 1));//페이드 아웃
            Invoke("LoadArcaive", 5);
        }

        if(isEnding) //보스와의 대화 이후
        {
            fadeEffect.StartCoroutine(fadeEffect.Fade(0, 1));//페이드 아웃
            Invoke("LoadEnding", 5);
        }
    }

    public void LoadDessert()
    {
        SceneManager.LoadScene("Dessert");
        //talkManager.isBuff = true;
    }

    public void LoadArcaive()
    {
        SceneManager.LoadScene("Arcaive");
        //talkManager.isBuff = true;
    }

    public void LoadEnding()
    {
        SceneManager.LoadScene("GameEnding");
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = true;
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Dialogue(objData.id, objData.isNpc);
        }
    }

    void Dialogue(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        
        if (talkData == null)
        {
            isAction = false;
            //talkIndex = 0; //인덱스 초기화, 다시 말 못걸게 하고 싶으면 여기를 지우면 됨
            return;
        }

        if (isNpc) //NPC일 경우
        {
            //talkText.text = scanObject.name + ": "+ talkData; //대화창 앞에 이름 띄우기
            talkText.text = scanObject.name + System.Environment.NewLine + talkData;
        }
        else //사물일 경우
        {
            talkManager.isBuff = false;
            talkText.text = talkData;
            //isEnding = true;
        }
        talkIndex++;

        if(id==2000 && talkIndex == 13) //최종보스와 대화, 뭐때문인지 lenth매서드가 적용이 안돼서 대사 늘어날때마다 바꿔줘야 함
        {
            isEnding = true;
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    //소드 쿨타임 관리
    public IEnumerator DashCool() 
    {
        StartCoroutine(CoolImg(dashCool, dashCoolImg));     //쿨타임 이미지 관리
        yield return new WaitForSeconds(dashCool);          //쿨타임 진행
        playerAttack.isDash = true;                         //쿨타임 종료 후 대쉬 가능
    }

    //파이어볼 쿨타임 관리
    public IEnumerator FireCool() 
    {
        StartCoroutine(CoolImg(fireCool, fireCoolImg));     //쿨타임 이미지 관리
        yield return new WaitForSeconds(fireCool);          //쿨타임 진행
        playerAttack.isFire = true;                         //쿨타임 종료 후 파이어 볼 가능
    }

    //리듬입력 쿨타임 관리
    public IEnumerator RhythmCool() 
    {
        StartCoroutine(CoolImg(rhythmCool, rhythmCoolImg)); //쿨타임 이미지 관리
        yield return new WaitForSeconds(rhythmCool);        //쿨타임 진행
        playerAttack.isRhythm = true;                       //쿨타임 종료 후 리듬 입력 가능
    }

    //쿨타임 이미지 관리
    public IEnumerator CoolImg(float time, Image img) 
    {
        float duration = time;
        while(time>0)
        {
            time -= 0.1f;
            img.fillAmount = time / duration;
            yield return seconds;
        }

        img.fillAmount = 0;
        time = 0;
    }
}
