using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }

    public override void EnterState(){
        base.EnterState();
        Debug.Log("AttackState");
    }
    public override void ExitState(){
        base.ExitState();
    }
    public override void FrameUpdate(){
        base.FrameUpdate();

        if(enemy.IsAggroed){
            enemy.StateMachine.ChangeState(enemy.MoveState);
        }
    }
    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
    }
    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType){
        base.AnimationTriggerEvent(triggerType);
    }
}
