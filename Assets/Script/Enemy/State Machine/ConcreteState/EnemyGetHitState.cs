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
        AnimatorStateInfo info = enemy.animator.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 0.9){
            enemy.takeHit = false;
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
