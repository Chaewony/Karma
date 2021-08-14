using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public GameManager gameManager;
    public PlayerMove playerMove;
    public NoteManager noteManager;
    public EffectManager effectManager;
    public CameraManager cameraManager;

    //소드 어택
    [SerializeField]
    private Collider2D swordCol; //소드 어택 콜라이더
    [SerializeField]
    private float swordAttackTime; //소드 어택 지속 시간 (애니메이션 실행 시간)

    //파이어볼 어택
    [SerializeField]
    private GameObject fireBall; //우측 파이어 볼 이펙트 오브젝트
    [SerializeField]
    private GameObject fireBallLeft; //좌측 파이어 볼 이펙트 오브젝트
    [SerializeField]
    private float fireAttackTime; //파이어 볼 어택 (애니메이션 실행 시간)

    //리듬 어택
    [SerializeField]
    private GameObject rhytnmUI; //리듬 어택 UI 오브젝트
    [SerializeField]
    private float getRhythmTime; //리듬 입력 지속 시간
    [SerializeField]
    private float rhythmAttackTime; //리듬 공격 지속 시간 (애니메이션 실행 시간)

    //쿨타임 관련
    private bool isRight; //플레이어가 오른 쪽을 바라보고 있을 때 true
    public bool isFire; //파이어 볼 어택 가능 시 (쿨타임 소진 시) true
    public bool isDash; //대쉬 가능 시 (쿨타임 소진 시) true
    public bool isRhythm; //리듬 어택 가능 시 (쿨타임 소진 시) true

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isFire = true;
        isDash = true;
        isRhythm = true;
    }

    void Update()
    {
        if (!this.spriteRenderer.flipX) //우측
        {
            swordCol.transform.eulerAngles = new Vector3(0, 0, 0); //소드 어택 콜라이더 우측
            isRight = true;
        }
        if (this.spriteRenderer.flipX) //좌측
        {
            swordCol.transform.eulerAngles = new Vector3(0, 180, 0); //소드 어택 콜라이더 좌측
            isRight = false;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //대쉬
    public IEnumerator DashCor() 
    {
        if (isDash)
        {
            isDash = false;                                  //쿨타임동안 대쉬 불가능
            StartCoroutine(gameManager.DashCool());          //쿨타임 호출

            playerMove.Dash();                               //대쉬 함수 호출
            yield return null;
        }
    }

    //소드 어택, 쿨타임 없음
    public IEnumerator Sword() 
    {
           swordCol.gameObject.SetActive(true);              //소드 콜라이더 컴포넌트 활성화
           anim.SetBool("isAttacking", true);                //애니메이션 실행
           yield return new WaitForSeconds(swordAttackTime); //애니메이션 지속
           anim.SetBool("isAttacking", false);               //애니메이션 종료
           swordCol.gameObject.SetActive(false);             //소드 콜라이더 비활성화
    }

    //파이어 볼 어택
    public IEnumerator FireBall() 
    {
        if(isRight&&isFire) //우측
        {
            isFire = false;                                  //쿨타임동안 파이어볼 어택 불가능
            StartCoroutine(gameManager.FireCool());          //쿨타임 호출

            fireBall.gameObject.SetActive(true);             //파이어 볼 컴포넌트 활성화
            anim.SetBool("isFire",true);
            yield return new WaitForSeconds(0.1f);           //애니메이션 지속
            anim.SetBool("isFire", false);
            yield return new WaitForSeconds(fireAttackTime); //공격 지속
            fireBall.gameObject.SetActive(false);            //파이어볼 컴포넌트 비활성화
        }
        else if(!isRight&&isFire)//좌측
        {
            isFire = false;
            StartCoroutine(gameManager.FireCool());

            fireBallLeft.gameObject.SetActive(true);
            anim.SetBool("isFire", true);
            yield return new WaitForSeconds(fireAttackTime);
            anim.SetBool("isFire", false);
            fireBallLeft.gameObject.SetActive(false);
        }
    }

    public IEnumerator Rhythm() //여기 고쳐야 됨
    {
        if(isRhythm)
        {
            effectManager.JudgementEffect(5);

            isRhythm = false;
            StartCoroutine(gameManager.RhythmCool());        //쿨타임 걸어주기

            noteManager.isRhythmKey = false;                 //초기화 시켜주기
            noteManager.score = 0;                           //시작 시 점수 초기화
            rhytnmUI.gameObject.SetActive(true);             
            yield return new WaitForSeconds(getRhythmTime);  //리듬 입력 지속 시간
            rhytnmUI.gameObject.SetActive(false);            //시간이 지나면 비활성화

            if (noteManager.score >= 100) //100점 이상이면 기술
            {
                anim.SetBool("isRhythm", true);
                cameraManager.isMove = true; //땅 흔들림 애니메이션
                yield return new WaitForSeconds(rhythmAttackTime);//공격 지속 시간
                anim.SetBool("isRhythm", false);
                cameraManager.isMove = false; //땅 흔들림 애니메이션 종료
                Debug.Log(noteManager.score);
            }
        }
    }

    /*private void StopRoutine(string skill, object a)
    {
        //attackRotine = null;
        anim.SetBool(skill, false);
    }*/
}
