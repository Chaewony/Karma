using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUpState : BossState //스테이트 상속
{
    private Boss boss;

    public void onEnter(Boss boss)
    {
        this.boss = boss;
    }

    public void Update()
    {
        boss.anim.SetTrigger("isUp"); // 애니메이션

        if(boss.distance>15.0f)
        {
            boss.SetState(new BossIdleState()); //대기 상태로 전환
        }

        if(boss.distance<10.0f)
        {
            boss.SetState(new BossAttackState()); //공격 상태로 전환
        }
    }

    public void onExit()
    {

    }
}
