using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private BossState currentState; //State를 상속
    public GameManager gameManager;
    public SpriteRenderer spriteRenderer;
    public Animator anim;
    public bool isPlayer = false; //플레이어 접근 확인
    public GameObject sandWind;

    [SerializeField]
    private Transform player;
    public Transform MyPlayer { get { return player; } }
    public float distance;

    [SerializeField]
    private GameObject attackCol; //공격 범위 콜리더

    // Start is called before the first frame update
    void Start()
    {
        SetState(new BossIdleState());
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sandWind.gameObject.SetActive(false);
        //enemyHp = enemyFullHp;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
        
        distance = Vector3.Distance(player.transform.position, this.transform.position);
    }

    public void SetState(BossState nextState)
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
            gameManager.isDessertBossDead = true;
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
}
