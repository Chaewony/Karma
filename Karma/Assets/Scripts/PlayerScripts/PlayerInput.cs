using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMove playerMove;
    private PlayerAttack playerAttack;
    private PlayerInteraction playerInteraction;
    
    [SerializeField]
    private Collider2D swordCol; //칼 콜리더
    [SerializeField]
    private GameObject fireBall; //오른쪽 파이어볼
    [SerializeField]
    private GameObject fireBallLeft; //왼쪽 파이어볼
    [SerializeField]
    private GameObject rhytnmUI;


    private float h;

    private void Awake()
    {
        swordCol.gameObject.SetActive(false);
        fireBall.gameObject.SetActive(false);
        fireBallLeft.gameObject.SetActive(false);
        rhytnmUI.gameObject.SetActive(false);
    }
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerAttack = GetComponent<PlayerAttack>();
        playerInteraction = GetComponent<PlayerInteraction>();   
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        AttackInput();
        InteractionInput();

        //움직임체크하는 인풋
        //점프 대쉬 더블점프 움직임 이동

        //공격 체크해주는 인풋
        //스킬공격 기본공격 연속공격

        //상호작용 체크해주는 인풋
        //스페이스 바 / 상자 밀기
    }

    private void FixedUpdate()
    {
        playerMove.Move(h); //좌우 이동
    }

    ////////////////////////////////////////////////////////////////////////////////////////////

    private void MovementInput()
    {
        h = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.A))//대쉬
        {
            StartCoroutine(playerAttack.DashCor()); //대쉬 코루틴
        }

        if (Input.GetKeyDown(KeyCode.Space)) //점프
        {
            playerMove.Jump();
        }
    }

    private void AttackInput() //공격
    {
        if (Input.GetKeyDown(KeyCode.S)) //소드
        {
            StartCoroutine(playerAttack.Sword());
        }

        if(Input.GetKeyDown(KeyCode.D)) //파이어볼
        {
            StartCoroutine(playerAttack.FireBall());
        }

        if (Input.GetKeyDown(KeyCode.F)) //리듬 스킬
        {
            StartCoroutine(playerAttack.Rhythm());
        }
        // if (can attack == true)점프공격 가능
        //    playerAttack.Attack();

        // if (can skillAttack == true)
        //    playerAttack.skillAttack();

        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            playerAttack.Attack();
        }*/
    }

    private void InteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //엔터가 리턴인가봄
        {
            playerInteraction.Talk();
        }
    }
}
