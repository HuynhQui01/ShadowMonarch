using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadState : EnemyState
{
    public BossDeadState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }
}
