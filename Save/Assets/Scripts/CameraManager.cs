using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform playerPos;
    private Animator anim;

    //경계값
    public float minX;
    public float minY;

    public float maxX;
    public float maxY;

    //플레이어에 대한 카메라의 상대적인 포지션 값(기본 설정에서 카메라 포지션에서 플레이어의 포지션을 뺀 값)
    public float relativePosX;
    public float relativePosY;

    public bool isMove;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(playerPos.position.x + relativePosX, minX, maxX);
        float y = Mathf.Clamp(playerPos.position.y + relativePosY, minY, maxY);
        this.transform.position = new Vector3(x, y, this.transform.position.z);

        //AnimationControl();
    }

    void AnimationControl()
    {
        if(isMove)
        {
            anim.SetBool("isMove", true);
        }
    }
}
