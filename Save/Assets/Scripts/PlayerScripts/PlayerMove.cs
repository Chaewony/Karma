using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    //이동관련변수
    [SerializeField]
    private float speed;
    private float speedTmp;

    [SerializeField]
    private float jumpPower;

    private bool isJump = false; //점프중인지 확인
    private bool isGround = false; //땅에 닿아있는지 확인
    private bool isDash = false;

    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        manager = GetComponent<GameManager>();

        speedTmp = speed;
    }

    // Update is called once per frame
    void Update()
    {
        AnimationController();
        //애니메이션 관리
    }

    //////////////////////////////////////////////////////////////////////////////

    // 이동
    public void Move(float h) //h는 호라이즌탈 값
    {
        rb.velocity = new Vector2(speed * h, rb.velocity.y);

        //좌우반전
        if (h == 1)
        {
            spriteRenderer.flipX = false;
        }
        else if (h == -1)
        {
            spriteRenderer.flipX = true;
        }
    }

    //대쉬
    public void Dash()
    {
        speed = 20;
        isDash = true;
        Invoke("SpeedReturn", 0.3f);
         //하고 아래 코드에서 애니메이션 구현
    }
    public void SpeedReturn()
    {
        speed = speedTmp; //처음 스피드
        isDash = false;
    }

    //점프
    public void Jump()
    {
        if (isGround == true)
        {
            rb.velocity += new Vector2(0, jumpPower);
            isGround = false;
            isJump = true;
        }
    }

    //애니메이션 관리
    private void AnimationController()
    {
        //걷기
        if (rb.velocity.x != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        //점프
        if (isJump == true)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false); ;
        }
        //대쉬
        if (isDash == true)
        {
            anim.SetBool("isDash", true);
        }
        if (isDash == false)
        {
            anim.SetBool("isDash", false);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            isGround = true;
            isJump = false;
        }
    }
}
