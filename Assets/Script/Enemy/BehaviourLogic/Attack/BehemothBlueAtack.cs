using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Blue Behemoth Atack", menuName = "Enemy Logic/Attack Logic/Blue Behemoth Atack")]
public class BehemothBlueAtack : EnemyAttackSOBase
{
    bool canAttack = true;
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        if (canAttack)
        {
            // enemy.MoveEnemy(Vector2.zero);

            enemy.animator.SetTrigger("Attack");
        }
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        if (canAttack)
        {
            Vector2 dir = (playerTransform.position - enemy.transform.position).normalized;
            enemy.MoveEnemy(dir * 2f);
        }
        if (enemy.takeHit)
        {
            enemy.StateMachine.ChangeState(enemy.GetHitState);
        }

        AnimatorStateInfo stateInfo = enemy.animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log(stateInfo.normalizedTime);
        if (stateInfo.normalizedTime >= 0.5f)
        {
            canAttack = false;
            AttackCD();
            enemy.MoveEnemy(Vector2.zero);
        }

        if (stateInfo.normalizedTime >= 1f)
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }

    }

    public override void DoPhysicUpdateLogic()
    {
        base.DoPhysicUpdateLogic();
    }

    async void AttackCD()
    {
        if (!canAttack)
        {
            await Task.Delay((int)(5f * 1000));
            canAttack = true;
        }
    }
}
