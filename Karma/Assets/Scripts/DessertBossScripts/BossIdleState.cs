using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossState
{
    private Boss boss;

    public void onEnter(Boss boss)
    {
        this.boss = boss;   
    }

    public void Update()
    {
        boss.anim.SetTrigger("isIdling"); //대기 애니메이션

        boss.transform.Translate(new Vector3(0, 0, 0)); //정지

        if(boss.distance<15.0f)
        {
            boss.SetState(new BossUpState()); //이동 상태로 전환
        }
    }

    public void onExit()
    {

    }
}
