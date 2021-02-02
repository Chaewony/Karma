using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : State //어택콜라이더에 플레이어의 칼 콜라이더가 닿으면 hp를 깎아줄거임
{
    private Enemy enemy;

    public void onEnter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    void State.Update()
    {
        /*if (isHurt)
        {
            enemy.anim.SetTrigger("isHurting");
            hp -= 10;
        }
        if (!isHurt)
        {
            enemy.SetState(new MoveState());
        }*/
    }

    public void onExit()
    {
        
    }
}
