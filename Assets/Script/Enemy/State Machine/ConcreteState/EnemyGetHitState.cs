using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetHitState : EnemyState
{
    public EnemyGetHitState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.animator.SetTrigger("GetHit");
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.takeHit = false;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate(); 
        if (enemy.animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "GetHit"){
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
