using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpBar : MonoBehaviour
{
    public float playerFullHp; //풀 체력
    public float playerHp; //현재 체력
    public Text hpValue;
    public Image hpImage;

    // Start is called before the first frame update
    void Start()
    {
        playerFullHp = 100;
        playerHp = playerFullHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpValue.text = playerHp + "/" + playerFullHp;
        hpImage.fillAmount = playerHp / playerFullHp;
        if (playerHp < 0)
        {
            playerHp = 0;
        }
    }
}
