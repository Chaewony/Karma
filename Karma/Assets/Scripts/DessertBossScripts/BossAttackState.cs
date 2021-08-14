using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossState
{
    Boss boss;

    public void onEnter(Boss boss)
    {
        this.boss = boss;
    }

    public void Update()
    {
        //boss.anim.SetTrigger("isAttacking");
        SandWind();
        if (boss.distance > 10.0f)
        {
            boss.SetState(new BossUpState());
        }
    }

    public void onExit()
    {

    }

    public void SandWind()
    {
        boss.sandWind.gameObject.SetActive(true);
    }
}
