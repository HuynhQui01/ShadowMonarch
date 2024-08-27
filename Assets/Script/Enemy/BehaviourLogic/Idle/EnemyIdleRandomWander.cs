using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idel-Random Wander", menuName = "Enemy Logic/Idel Logic/ Random Wander")]
public class EnemyIdleRandomWander : EnemyIdelSOBase
{
    [SerializeField] private float RandomMovementRange = 5f;
    [SerializeField] private float RandomMovementSpeed = 1f;

    Vector3 targetPos;
    Vector3 dir;
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);

    }

    public override void DoEnterLogic(){
        base.DoEnterLogic();
        targetPos = GetRandomPointInCircle();
        enemy.animator.SetBool("IsRun", true);
    }

    public override void DoExitLogic(){
        base.DoExitLogic();
        enemy.animator.SetBool("IsRun", false);

    }

    public override void DoFrameUpdateLogic(){
        base.DoFrameUpdateLogic();
        if(enemy.takeHit){
            enemy.StateMachine.ChangeState(enemy.GetHitState);
        }
        if(enemy.IsAggroed){
            enemy.StateMachine.ChangeState(enemy.MoveState);
        }
        if(enemy.IsWithinStrikingDistance){
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }
        
        dir = (targetPos - enemy.transform.position).normalized;
        enemy.MoveEnemy(dir * RandomMovementSpeed);
        if((enemy.transform.position - targetPos).sqrMagnitude < 0.01f){
            targetPos = GetRandomPointInCircle();
        }
    }

    public override void DoPhysicUpdateLogic(){
        base.DoPhysicUpdateLogic();
    }

    Vector3 GetRandomPointInCircle(){
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * RandomMovementRange;
    }
}
