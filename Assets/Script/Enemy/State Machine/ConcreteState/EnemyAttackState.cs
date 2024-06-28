using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    // bool animationFinished = false;

    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }

    public override void EnterState()
    {
        
        base.EnterState();
        enemy.EnemyAttackBaseInstance.DoEnterLogic();
    }
    public override void ExitState()
    {
        base.ExitState();
        enemy.EnemyAttackBaseInstance.DoExitLogic();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.EnemyAttackBaseInstance.DoFrameUpdateLogic();
        


        // if (enemy.animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Attack")
        // {

        //     enemy.StateMachine.ChangeState(enemy.IdleState);
        // }



    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        enemy.EnemyAttackBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }
}
