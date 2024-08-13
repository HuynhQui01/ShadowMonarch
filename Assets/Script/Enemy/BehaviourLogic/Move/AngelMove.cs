using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[CreateAssetMenu(fileName = "Angel Move", menuName = "Enemy Logic/Move Logic/Angel Move")]

public class AngelMove : EnemyMoveSOBase
{

    bool canAttack = true;
    Vector2 moveDir;
    [SerializeField] private float movementSpeed = 0.5f;

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
        moveDir = (playerTransform.position - enemy.transform.position).normalized;
        base.DoFrameUpdateLogic();
        if (enemy.takeHit)
        {
            enemy.StateMachine.ChangeState(enemy.GetHitState);
        }
        if (canAttack)
        {
            enemy.animator.SetBool("IsRun", true);
            enemy.MoveEnemy(moveDir * 4.5f);
            canAttack = false;
            AttackCD();
        }
        if (enemy.IsWithinStrikingDistance)
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
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
            await Task.Delay((int)(10f * 1000));
            canAttack = true;
        }
    }
}
