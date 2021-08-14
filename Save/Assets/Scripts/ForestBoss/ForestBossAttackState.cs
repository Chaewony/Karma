using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBossAttackState : ForestBossState
{
    ForestBoss forestBoss;

    public void onEnter(ForestBoss forestBoss)
    {
        this.forestBoss = forestBoss;
    }

    public void Update()
    {
        forestBoss.anim.SetTrigger("isAttacking");

        if (forestBoss.distance > 10.0f)
        {
            forestBoss.SetState(new ForestBossBasicState());
        }
    }

    public void onExit()
    {
        
    }
}
