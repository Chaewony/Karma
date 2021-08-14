using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    void onEnter(Enemy enemy); //상태 진입했을때 어떤 행동을 할 지
    void Update(); //진행중일때 뭘 할 지
    void onExit(); // 끝났을 때 뭘 할 지
}
