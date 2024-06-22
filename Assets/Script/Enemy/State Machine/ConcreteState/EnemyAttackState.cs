using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }

    public override void EnterState(){
        enemy.MoveEnemy(Vector2.zero);
        enemy.animator.SetTrigger("Attack");
        base.EnterState();
    }
    public override void ExitState(){
        base.ExitState();
    }
    public override void FrameUpdate(){
        base.FrameUpdate();
        
        if(enemy.animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Attack"){

        enemy.StateMachine.ChangeState(enemy.IdleState);
        }
        
    
    }
    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
    }
    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType){
        base.AnimationTriggerEvent(triggerType);
    }
}
