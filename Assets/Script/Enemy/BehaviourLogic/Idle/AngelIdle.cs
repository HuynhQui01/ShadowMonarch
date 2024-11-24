using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Angel Idle", menuName = "Enemy Logic/Idel Logic/Angel Idle")]

public class AngelIdle : EnemyIdelSOBase
{
    [SerializeField] private float RandomMovementRange = 5f;
    [SerializeField] private float RandomMovementSpeed = 0.5f;

    Vector3 targetPos;
    Vector3 dir;
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);

    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        targetPos = GetRandomPointInCircle();

    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        if (enemy.takeHit)
        {
            enemy.StateMachine.ChangeState(enemy.GetHitState);
        }
        if (enemy.IsAggroed)
        {
            enemy.StateMachine.ChangeState(enemy.MoveState);
        }

        dir = (targetPos - enemy.transform.position).normalized;
        enemy.MoveEnemy(dir * RandomMovementSpeed);
        
        if ((enemy.transform.position - targetPos).sqrMagnitude < 0.01f)
        {
            targetPos = GetRandomPointInCircle();
        }
    }

    public override void DoPhysicUpdateLogic()
    {
        base.DoPhysicUpdateLogic();
    }

    Vector3 GetRandomPointInCircle()
    {
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * RandomMovementRange;
    }
}
