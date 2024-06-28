using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{
    public EnemyDeadState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.animator.SetBool("IsDead", true);
         AnimatorStateInfo stateInfo = enemy.animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 0.4f)
        {
            enemy.Die();
        }

    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
       

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
