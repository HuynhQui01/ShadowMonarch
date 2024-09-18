using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{

    public float experience = 5f;
    public EnemyDeadState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.isDead = true;
        enemy.animator.SetBool("IsDead", true);
        enemy.player.Experience += experience;
        enemy.player.SetSoulPoint();
        
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        AnimatorStateInfo stateInfo = enemy.animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log(stateInfo.normalizedTime);
        if (stateInfo.normalizedTime >= 1f)
        {
            enemy.Die();
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
