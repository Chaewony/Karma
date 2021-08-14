using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;
    //float fades = 1.0f; //페이드 값
    //bool doDestroy = false; //노트 파괴 여부
    public bool isRhythmKey = false;  //F키 
    //private bool isOnce=true;
    //private int callcount;

    //int skill_stack = 0;    // (임시용)리듬 입력을 사용하기 위핸 필요 스택 개수(나중에 인자로 받아올 것)

    public List<GameObject> NoteList = new List<GameObject>();  // 노트들을 리스트에 저장시키기 위해 NoteList 리스트 선언

    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject goNote = null;

    EffectManager theEffect;

    //판정할 때 점수 주고 점수 몇 점 이상이면 스킬나가고 미만이면 못나가게 하는걸로. 마지막에 카운트 값 초기화 시켜줘야 함
    public float score = 0; //점수초기화는 다른 스크립트에서 해줘야겠다.

    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GetNote();
    }

    public void GetNote()
    {
        currentTime += Time.deltaTime;

        bpm = Random.Range(0, 200); //랜덤 박자에 따른 노트 생성
        if (currentTime >= 100d / bpm)
        {
            CreateNote();
            currentTime -= 100d / bpm;
        }

        // 판정
        if (NoteList.Count > 0) // 판정을 받을 노트 리스트가 0개 초과이면, 노트 생성과 동시에 노트리스트에 값이 추가되는것같음
        {
            //theEffect.JudgementEffect(4);
            if (Input.GetKeyDown(KeyCode.F) && !isRhythmKey)    // 키 입력을 받았을 때
            {
                isRhythmKey = true;
                if (NoteList[0].transform.localScale.x > 0.9f+0.3f && NoteList[0].transform.localScale.x <= 1.1f+0.3f)  // Perfect
                {
                    Debug.Log("Perfect!");
                    score += 100; //점수
                    theEffect.JudgementEffect(0);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    //StartCoroutine(Fade());
                    //doDestroy = true;
                    RemoveNote();
                }
                else if (NoteList[0].transform.localScale.x > 1.1f+0.3f && NoteList[0].transform.localScale.x <= 1.3f+0.3f)   // Great
                {
                    Debug.Log("Great!");
                    score += 80; //점수
                    theEffect.JudgementEffect(1);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    //StartCoroutine(Fade());
                    RemoveNote();
                }
                else if (NoteList[0].transform.localScale.x > 1.3f+0.3f && NoteList[0].transform.localScale.x <= 1.7f+0.3f)   // Good
                {
                    Debug.Log("Good!");
                    score += 60; //점수
                    theEffect.JudgementEffect(2);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    //StartCoroutine(Fade());
                    RemoveNote();
                }
                else if (NoteList[0].transform.localScale.x > 1.7f+0.3f && NoteList[0].transform.localScale.x <= 2.1f+0.3f)   // Bad
                {
                    Debug.Log("Bad!");
                    score += 40; //점수
                    theEffect.JudgementEffect(3);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    //StartCoroutine(Fade());
                    RemoveNote();
                }
                else if (NoteList[0].transform.localScale.x > 2.1f+0.3f) // Miss
                {
                    Debug.Log("Miss!");
                    score += 20; //점수
                    theEffect.JudgementEffect(4);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    //StartCoroutine(Fade());
                    RemoveNote();
                }
                //fades = 1.0f;   // fades 값 1.0으로 초기화
            }

            else if (NoteList[0].transform.localScale.x <= 1.1f)    // 키 입력을 받지 못했을 때
            {
                Debug.Log("No HIT");
                score += 0; //점수
                theEffect.JudgementEffect(4);
                Destroy(NoteList[0]);
                NoteList.Remove(NoteList[0]);
                isRhythmKey = false;
            }
        }
    }

    void CreateNote()   //Create Note
    {
        GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);

        t_note.AddComponent<SpriteRenderer>();
        NoteList.Add(t_note);
        t_note.transform.SetParent(this.transform);
    }

    void RemoveNote()   // 노트 제거 함수, 게임 오브젝트 삭제
    {
        isRhythmKey = false;
        Destroy(NoteList[0]);
        NoteList.Remove(NoteList[0]);
    }

    /*IEnumerator Fade()  // 페이드 아웃 및 노트 제거 함수, 리스트에서 삭제
    {
        *//*for (float i = 1.0f; i >= 0f; i -= 0.01f)
        {
            NoteList[0].GetComponent<Image>().color = new Color(1f, 1f, 1f, i);
            yield return null;
        }*//*
        RemoveNote();
        yield return null;
    }*/
}
