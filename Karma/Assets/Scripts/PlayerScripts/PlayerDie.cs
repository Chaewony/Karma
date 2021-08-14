using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    public HpBar hpBar;
    private SpriteRenderer spriteRenderer;
    //private Animator anim;
    public FadeEffect fadeEffect;
    public Transform playerPos;
    //public Image playerImage;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpBar.playerHp == 0) //체력사
        {
            Die();
        }

        if (playerPos.position.y < -80) //낙사
        {
            Die();
        }
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    //죽음
    private void Die()
    {
        spriteRenderer.color = new Color(255, 0, 0); //빨간색

        StartCoroutine(Fade(1, 0));//플레이어 페이드아웃

        fadeEffect.StartCoroutine(fadeEffect.Fade(0, 1));//페이드 아웃
        Invoke("LoadGameOver", 5);
    }

    //플레이어 전용 페이드 아웃
    public IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            //fadeTime으로 나누어서 fadeTime시간동안 percent값이 0에서 1로 증가하도록 함
            currentTime += Time.deltaTime;
            percent = currentTime / 0.5f;

            //알파값을 start부터 end까지 fadeTime 시간 동안 변화시킨다.
            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(start, end, percent);
            spriteRenderer.color = color;

            yield return null;
        }
    }
}
