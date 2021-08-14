using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private Enemy enemy;

    public void onEnter(Enemy enemy)
    {
        this.enemy = enemy;   
    }

    public void Update()
    {
        enemy.anim.SetTrigger("isIdling"); //대기 애니메이션

        enemy.transform.Translate(new Vector3(0, 0, 0)); //정지

        if(enemy.distance<15.0f)
        {
            enemy.SetState(new MoveState()); //이동 상태로 전환
        }
    }

    public void onExit()
    {

    }
}
