using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private State currentState; //State를 상속
    public GameManager gameManager;
    public SpriteRenderer spriteRenderer;
    public Animator anim;
    public bool flip;
    public bool isPlayer = false; //플레이어 접근 확인
    //public int enemyFullHp = 100;
    //public int enemyHp;
    

    [SerializeField]
    private Transform player;
    public Transform MyPlayer { get { return player; } }
    public float distance;

    [SerializeField]
    private Transform enemyRemain;
    public Transform MyEnemyRemain { get { return enemyRemain; } }

    //[SerializeField]
    //private GameObject chaseCol; //추적 범위 콜리더
    public float speed; //추적 속도

    [SerializeField]
    private GameObject attackCol; //공격 범위 콜리더

    private Rigidbody2D rb;
    private Vector3 dirVec;
    private RaycastHit2D rayHit;

    // Start is called before the first frame update
    void Start()
    {
        SetState(new MoveState());
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //enemyHp = enemyFullHp;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
        
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        spriteRenderer.flipX = flip;
        
        if(!flip) //우측
        {
            //chaseCol.transform.eulerAngles = new Vector3(0, 0, 0); //추적범위 좌우반전
            attackCol.transform.eulerAngles = new Vector3(0, 0, 0); //공격범위 좌우반전
            dirVec = Vector2.right; //레이캐스트 방향
        }
        if(flip) //좌측
        {
            //chaseCol.transform.eulerAngles = new Vector3(0, 180, 0); //추적범위 좌우반전
            attackCol.transform.eulerAngles = new Vector3(0, 180, 0); //공격범위 좌우반전
            dirVec = Vector2.left;
        }

        //레이캐스팅
        Debug.DrawRay(rb.position, dirVec * 3.5f, new Color(0, 1, 0));
        rayHit = Physics2D.Raycast(rb.position, dirVec, 3.5f, LayerMask.GetMask("Player"));
        
        if (rayHit.collider != null) //플레이어 접근 감지 시
        {
            isPlayer = true;
        }
        else //플레이어 접근 X시
        {
            isPlayer = false;
        }
    }

    public void SetState(State nextState)
    {
        if (currentState != null) // 예외처리
        {
            currentState.onExit();
        }

        currentState = nextState; //현재상태를 다음상태로 바꿔줌
        currentState.onEnter(this);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "PlayerAttack") //플레이어 공격 감지 시
        {
            //enemyHp -= 10;
            //this.spriteRenderer.color = new Color(1, 0.5f, 0.5f, 1); //연한 빨간색
            //Debug.Log(enemyHp);
            gameManager.deathCount++;
            Destroy(this.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "PlayerAttack") //플레이어 공격 X시 사용
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }

    /*공격감지코드와 플레이어 감지 코드, 왜 이렇게 짰는가?
     
     최초의 문제. 플레이어가 플레이어 감지 콜라이더 안에서 공격을 하면 에너미에 닿지 않고도 공격이 가능했다.
     그래서 여러가지 시도 끝에 레이캐스팅과 온트리거 두 가지를 같이 사용하기로 했다. 
     (플레이어 감지 콜라이더를 move state일때만 켜는 시도도 해봄. 한계가 있음)
     
     방법1. 레이캐스팅 -> 플레이어 감지, 온트리거 -> 공격 감지
     성공!
     */
}
