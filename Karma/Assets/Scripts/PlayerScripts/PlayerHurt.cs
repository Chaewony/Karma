using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public HpBar hpBar;
    private SpriteRenderer spriteRenderer;
    public Collider2D playercoll;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            /*if(coll!=playercoll)
            {
                hpBar.playerHp -= 10; //체력 감소
                spriteRenderer.color = new Color(1, 0.5f, 0.5f, 1); //연한 빨간색
                Debug.Log("맞음");
            }*/
            hpBar.playerHp -= 10; //체력 감소
            spriteRenderer.color = new Color(1, 0.5f, 0.5f, 1); //연한 빨간색
        }

        //Debug.Log(coll);
        /*if (coll==playercoll && coll.gameObject.tag == "Enemy")
        {
            hpBar.playerHp -= 10; //체력 감소
            spriteRenderer.color = new Color(1, 0.5f, 0.5f, 1); //연한 빨간색
            Debug.Log("맞음");
        }*/
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }
}
