using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    Transform playerTransform;
    float movementSpeed = 0.5f;
    public EnemyMoveState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void EnterState()
    {
        base.EnterState();

        // Debug.Log("move state");
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.animator.SetBool("IsRun", true);

        Vector2 moveDir = (playerTransform.position - enemy.transform.position).normalized;
        enemy.MoveEnemy(moveDir * movementSpeed);

        if (enemy.IsWithinStrikingDistance)
        {
            enemy.animator.SetBool("IsRun", false);
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }
}
