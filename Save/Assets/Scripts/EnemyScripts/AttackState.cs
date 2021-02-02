using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    Enemy enemy;

    public void onEnter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Update()
    {
        enemy.anim.SetTrigger("isAttacking");
        
        if (enemy.distance > 1.25f)
        {
            enemy.SetState(new MoveState());
        }
    }

    public void onExit()
    {

    }
}
