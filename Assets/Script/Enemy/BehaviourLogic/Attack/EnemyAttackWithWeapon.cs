using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack-With-Weapon", menuName = "Enemy Logic/Attack Logic/Attack With Weapon")]
public class EnemyAttackWithWeapon : EnemyAttackSOBase
{
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public override void DoEnterLogic(){
        base.DoEnterLogic();
        enemy.MoveEnemy(Vector2.zero);
        enemy.animator.SetTrigger("Attack");

    }

    public override void DoExitLogic(){
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic(){
        base.DoFrameUpdateLogic();
        if(enemy.takeHit){
            enemy.StateMachine.ChangeState(enemy.GetHitState);
        }

        AnimatorStateInfo stateInfo = enemy.animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1.0f )
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
        
    }

    public override void DoPhysicUpdateLogic(){
        base.DoPhysicUpdateLogic();
    }

    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }
}
