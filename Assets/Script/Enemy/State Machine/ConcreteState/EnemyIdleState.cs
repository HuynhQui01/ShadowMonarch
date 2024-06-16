using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    Vector3 targetPos;
    Vector3 dir;
    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void EnterState(){
        base.EnterState();
        targetPos = GetRandomPointInCircle();
    }
    public override void ExitState(){
        base.ExitState();
    }
    public override void FrameUpdate(){
        base.FrameUpdate();
        if(enemy.IsAggroed){
            enemy.StateMachine.ChangeState(enemy.MoveState);
        }
        dir = (targetPos - enemy.transform.position).normalized;
        enemy.MoveEnemy(dir * enemy.RandomMovementSpeed);
        if((enemy.transform.position - targetPos).sqrMagnitude < 0.01f){
            targetPos = GetRandomPointInCircle();
        }
    }
    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
    }
    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType){
        base.AnimationTriggerEvent(triggerType);
    }

    Vector3 GetRandomPointInCircle(){
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.RandomMovementRange;
    }
}
