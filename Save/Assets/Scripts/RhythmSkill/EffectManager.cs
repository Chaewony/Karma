using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    [SerializeField] Animator judgementAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgementImage = null;
    [SerializeField] Sprite[] judgementSprite = null;

    //이펙트 원 관련
    [SerializeField]
    private GameObject effectCircle;

    [SerializeField] UnityEngine.UI.Image judgementCircleImage = null;
    [SerializeField] Sprite[] judgementCircleSprite = null;

    private void Update()
    {
        //judgementCircleImage.sprite = judgementCircleSprite[5];
    }

    public void JudgementEffect(int p_num) //판정 결과 이미지 ex)perfect,good...
    {
        judgementImage.sprite = judgementSprite[p_num];
        judgementAnimator.SetTrigger("Hit");

        judgementCircleImage.sprite = judgementCircleSprite[p_num];
        Invoke("Wait", 0.3f);
    }

    private void Wait()
    {
        judgementCircleImage.sprite = judgementCircleSprite[5];
    }
}
