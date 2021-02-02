using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private State currentState; //State를 상속
    private SpriteRenderer spriteRenderer;
    public Animator anim;
    public bool flip;

    [SerializeField]
    private Transform player;
    public Transform MyPlayer { get { return player; } }
    public float distance;

    [SerializeField]
    private Transform enemyRemain;
    public Transform MyEnemyRemain { get { return enemyRemain; } }

    [SerializeField]
    private GameObject chaseCol; //추적 범위 콜리더
    public float speed; //추적 속도
    public bool isPlayer = false; //플레이어 접근 확인

    [SerializeField]
    private GameObject attackCol; //공격 범위 콜리더

    // Start is called before the first frame update
    void Start()
    {
        SetState(new MoveState());
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
        
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        spriteRenderer.flipX = flip;
        
        if(!flip) //우측
        {
            chaseCol.transform.eulerAngles = new Vector3(0, 0, 0); //추적범위 좌우반전
            attackCol.transform.eulerAngles = new Vector3(0, 0, 0); //공격범위 좌우반전
        }
        if(flip) //좌측
        {
            chaseCol.transform.eulerAngles = new Vector3(0, 180, 0); //추적범위 좌우반전
            attackCol.transform.eulerAngles = new Vector3(0, 180, 0); //공격범위 좌우반전
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

    void OnTriggerEnter2D(Collider2D coll) //플레이어가 콜리더 안에 진입할 때
    {
        if (coll.gameObject.tag == "Player")
        {
            isPlayer = true;
        }
    }
    void OnTriggerStay2D(Collider2D coll) //플레이어가 콜리더 안에 있을 때
    {
        if (coll.gameObject.tag == "Player")
        {
            isPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D coll) //플레이어가 콜리더 밖에 있을 때
    {
        if (coll.gameObject.tag == "Player")
        {
            isPlayer = false;
        }
    }
}
