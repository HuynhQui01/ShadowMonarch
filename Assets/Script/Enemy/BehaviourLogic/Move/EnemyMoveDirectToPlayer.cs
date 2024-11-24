using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Move-Direct Move", menuName = "Enemy Logic/Move Logic/Direct Move")]
public class EnemyMoveDirectToPlayer : EnemyMoveSOBase
{
    [SerializeField] private float movementSpeed = 0.5f;

    float timeToChangeState;
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        enemy.animator.SetBool("IsRun", true);
        Debug.Log("Run");
        SetTime(5f);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        if (timeToChangeState > 0)
        {
            timeToChangeState -= Time.deltaTime;
        }
        Vector2 moveDir = (playerTransform.position - enemy.transform.position).normalized;
        enemy.MoveEnemy(moveDir * movementSpeed);

        if (enemy.takeHit)
        {
            enemy.StateMachine.ChangeState(enemy.GetHitState);
        }

        if (enemy.IsWithinStrikingDistance && timeToChangeState <= 0)
        {
            Debug.Log("Change to AttackState");
            enemy.StateMachine.ChangeState(enemy.AttackState);
            return;
        }

    }

    public override void DoPhysicUpdateLogic()
    {
        base.DoPhysicUpdateLogic();
    }



    void SetTime(float duration)
    {
        timeToChangeState = duration;
    }

}
