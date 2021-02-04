using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;
    //float fades = 1.0f; //���̵� ��
    //bool doDestroy = false; //��Ʈ �ı� ����
    public bool isRhythmKey = false;  //FŰ 
    //private bool isOnce=true;
    //private int callcount;

    //int skill_stack = 0;    // (�ӽÿ�)���� �Է��� ����ϱ� ���� �ʿ� ���� ����(���߿� ���ڷ� �޾ƿ� ��)

    public List<GameObject> NoteList = new List<GameObject>();  // ��Ʈ���� ����Ʈ�� �����Ű�� ���� NoteList ����Ʈ ����

    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject goNote = null;

    EffectManager theEffect;

    //������ �� ���� �ְ� ���� �� �� �̻��̸� ��ų������ �̸��̸� �������� �ϴ°ɷ�. �������� ī��Ʈ �� �ʱ�ȭ ������� ��
    public float score = 0; //�����ʱ�ȭ�� �ٸ� ��ũ��Ʈ���� ����߰ڴ�.

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

        bpm = Random.Range(0, 200); //���� ���ڿ� ���� ��Ʈ ����
        if (currentTime >= 100d / bpm)
        {
            CreateNote();
            currentTime -= 100d / bpm;
        }

        // ����
        if (NoteList.Count > 0) // ������ ���� ��Ʈ ����Ʈ�� 0�� �ʰ��̸�, ��Ʈ ������ ���ÿ� ��Ʈ����Ʈ�� ���� �߰��Ǵ°Ͱ���
        {
            //theEffect.JudgementEffect(4);
            if (Input.GetKeyDown(KeyCode.F) && !isRhythmKey)    // Ű �Է��� �޾��� ��
            {
                isRhythmKey = true;
                if (NoteList[0].transform.localScale.x > 0.9f+0.3f && NoteList[0].transform.localScale.x <= 1.1f+0.3f)  // Perfect
                {
                    Debug.Log("Perfect!");
                    score += 100; //����
                    theEffect.JudgementEffect(0);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    //StartCoroutine(Fade());
                    //doDestroy = true;
                    RemoveNote();
                }
                else if (NoteList[0].transform.localScale.x > 1.1f+0.3f && NoteList[0].transform.localScale.x <= 1.3f+0.3f)   // Great
                {
                    Debug.Log("Great!");
                    score += 80; //����
                    theEffect.JudgementEffect(1);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    //StartCoroutine(Fade());
                    RemoveNote();
                }
                else if (NoteList[0].transform.localScale.x > 1.3f+0.3f && NoteList[0].transform.localScale.x <= 1.7f+0.3f)   // Good
                {
                    Debug.Log("Good!");
                    score += 60; //����
                    theEffect.JudgementEffect(2);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    //StartCoroutine(Fade());
                    RemoveNote();
                }
                else if (NoteList[0].transform.localScale.x > 1.7f+0.3f && NoteList[0].transform.localScale.x <= 2.1f+0.3f)   // Bad
                {
                    Debug.Log("Bad!");
                    score += 40; //����
                    theEffect.JudgementEffect(3);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    //StartCoroutine(Fade());
                    RemoveNote();
                }
                else if (NoteList[0].transform.localScale.x > 2.1f+0.3f) // Miss
                {
                    Debug.Log("Miss!");
                    score += 20; //����
                    theEffect.JudgementEffect(4);
                    NoteList[0].GetComponent<Note>().enabled = false;
                    //StartCoroutine(Fade());
                    RemoveNote();
                }
                //fades = 1.0f;   // fades �� 1.0���� �ʱ�ȭ
            }

            else if (NoteList[0].transform.localScale.x <= 1.1f)    // Ű �Է��� ���� ������ ��
            {
                Debug.Log("No HIT");
                score += 0; //����
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

    void RemoveNote()   // ��Ʈ ���� �Լ�, ���� ������Ʈ ����
    {
        isRhythmKey = false;
        Destroy(NoteList[0]);
        NoteList.Remove(NoteList[0]);
    }

    /*IEnumerator Fade()  // ���̵� �ƿ� �� ��Ʈ ���� �Լ�, ����Ʈ���� ����
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
