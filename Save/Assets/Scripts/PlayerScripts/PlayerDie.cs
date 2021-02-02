using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    public HpBar hpBar;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    public FadeEffect fadeEffect;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpBar.playerHp == 0) //게임 종료
        {
            anim.SetTrigger("isDead");
            fadeEffect.StartCoroutine(fadeEffect.Fade(0, 1));//페이드 아웃
            Invoke("LoadGameOver", 5);
        }
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
