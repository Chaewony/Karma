using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State //스테이트 상속
{
    private Enemy enemy;

    public void onEnter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Update()
    {
        enemy.anim.SetTrigger("isWalking"); //걷기 애니메이션

        if (!enemy.isPlayer) //플레이어가 추적범위 안에 없을 경우
        {
            if (!enemy.flip)
            {
                MoveRight(); //오른쪽으로 움직이기
            }

            else if (enemy.flip)
            {
                MoveLeft(); //왼쪽으로 움직이기
            }
        }

        if (enemy.isPlayer) //플레이어가 추적범위 안에 있을 경우
        {
            MoveToPlayer(); //플레이어 추적
        }

        if(enemy.distance>15.0f)
        {
            enemy.SetState(new IdleState()); //대기 상태로 전환
        }

        if(enemy.distance<1.25f)
        {
            enemy.SetState(new AttackState()); //공격 상태로 전환
        }

        //방향결정
        //거리 결정
        //이동
        //플레이어와 거리 계산
        //상태 전환
    }

    public void onExit()
    {

    }
    
    /////////////////////////////////////////////////////////////////////////////////////////////////
    public void MoveRight()
    {
        enemy.transform.Translate(new Vector3(0.01f, 0, 0)); //오른쪽으로 움직이기 속도
        enemy.flip = false; //좌우반전

        if (enemy.transform.position.x > enemy.MyEnemyRemain.position.x + 1.0f)
        {
            MoveLeft();
        }
    }

    public void MoveLeft()
    {
        enemy.transform.Translate(new Vector3(-0.01f, 0, 0)); //왼쪽으로 움직이기 속도
        enemy.flip = true; //좌우반전

        if (enemy.transform.position.x < enemy.MyEnemyRemain.position.x - 1.0f)
        {
            MoveRight();
        }
    }

    public void MoveToPlayer() //플레이어 추적
    {
        enemy.transform.position = new Vector3(Mathf.MoveTowards(enemy.transform.position.x, enemy.MyPlayer.position.x, enemy.speed * Time.deltaTime), enemy.transform.position.y, enemy.transform.position.z);
    }
}
