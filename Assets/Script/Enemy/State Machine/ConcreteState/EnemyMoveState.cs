using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
        public EnemyMoveState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.EnemyMoveBaseInstance.DoEnterLogic();

        // Debug.Log("move state");
    }
    public override void ExitState()
    {
        base.ExitState();
        enemy.EnemyMoveBaseInstance.DoExitLogic();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.EnemyMoveBaseInstance.DoFrameUpdateLogic();
        
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemy.EnemyMoveBaseInstance.DoPhysicUpdateLogic();
    }
}
