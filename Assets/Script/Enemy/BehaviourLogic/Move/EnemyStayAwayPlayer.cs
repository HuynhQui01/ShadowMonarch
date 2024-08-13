using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stay Away Player", menuName = "Enemy Logic/Move Logic/Stay Away Player")]
public class EnemyStayAwayPlayer : EnemyMoveSOBase
{
    [SerializeField] private float moveSpeed = 0.5f;
    public float minDistance = 0.75f; 
    public float maxDistance = 1f; 
    
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        enemy.animator.SetBool("IsRun", false);
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        if (enemy.takeHit)
        {
            enemy.StateMachine.ChangeState(enemy.GetHitState);
        }
        if (enemy.IsWithinStrikingDistance)
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance < minDistance)
        {
            Vector3 direction = transform.position - playerTransform.position;
            enemy.RB.velocity = direction.normalized * moveSpeed;
        }
        else if (distance > maxDistance)
        {
            Vector3 direction = playerTransform.position - transform.position;
            enemy.RB.velocity = direction.normalized * moveSpeed;
        }
        else
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void DoPhysicUpdateLogic()
    {
        base.DoPhysicUpdateLogic();
    }
}
