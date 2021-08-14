using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBossBasicState : ForestBossState
{
    private ForestBoss forestBoss;

    public void onEnter(ForestBoss forestBoss)
    {
        this.forestBoss = forestBoss;
    }

    void ForestBossState.Update()
    {
        forestBoss.anim.SetTrigger("isBasic"); // 애니메이션

        if (forestBoss.distance < 10.0f)
        {
            forestBoss.SetState(new ForestBossAttackState()); //공격 상태로 전환
        }
    }

    public void onExit()
    {
        
    }
}
