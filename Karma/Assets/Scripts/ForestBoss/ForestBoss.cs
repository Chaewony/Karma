using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBoss : MonoBehaviour
{
    private ForestBossState currentState; //State를 상속
    public GameManager gameManager;
    public SpriteRenderer spriteRenderer;
    public Animator anim;
    public bool isPlayer = false; //플레이어 접근 확인
    //public int forestBossFullHp = 100;
    //public int forestBossHp;


    [SerializeField]
    private Transform player;
    public Transform MyPlayer { get { return player; } }
    public float distance;

    [SerializeField]
    private GameObject attackCol; //공격 범위 콜리더

    // Start is called before the first frame update
    void Start()
    {
        SetState(new ForestBossBasicState());
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        //forestBossHp = forestBossFullHp;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();

        distance = Vector3.Distance(player.transform.position, this.transform.position);
    }

    public void SetState(ForestBossState nextState)
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
            gameManager.isForestBossDead = true;
            Destroy(this.gameObject);

            /*forestBossHp -= 10;
            this.spriteRenderer.color = new Color(1, 0.5f, 0.5f, 1); //연한 빨간색
            Debug.Log(forestBossHp);
            if(forestBossHp<0)
            {
                gameManager.isForestBossDead = true;
                Destroy(this.gameObject);
            }*/
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "PlayerAttack") //플레이어 공격 X시 사용
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }
}
