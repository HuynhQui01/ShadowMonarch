using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[CreateAssetMenu(fileName = "Vampire Move", menuName = "Enemy Logic/Move Logic/Vampire Move")]

public class VampireMove : EnemyMoveSOBase
{
    bool canMove = true;

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        enemy.animator.SetBool("IsRun", false);

    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        enemy.animator.SetBool("IsRun", false);
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        AnimatorStateInfo info = enemy.animator.GetCurrentAnimatorStateInfo(0);
        if (enemy.takeHit)
        {
            enemy.StateMachine.ChangeState(enemy.GetHitState);
        }
        if (canMove)
        {
            enemy.animator.SetBool("IsRun", true);

            float normalizedTime = Mathf.Repeat(info.normalizedTime, 0.7f);
            if (normalizedTime >= 0.6f)
            {
                enemy.CheckForLeftOrRightFacing(playerTransform.position - enemy.transform.position);
                enemy.RB.MovePosition(playerTransform.position);
                canMove = false;
                MoveCD();
            }
            // Debug.Log(normalizedTime);
        }
        if (enemy.IsWithinStrikingDistance)
        {
            if (info.normalizedTime >= 1)
            {
                enemy.StateMachine.ChangeState(enemy.AttackState);
            }
        }

    }

    public override void DoPhysicUpdateLogic()
    {
        base.DoPhysicUpdateLogic();
    }

    async void MoveCD()
    {
        if (!canMove)
        {
                await Task.Delay((int)(1f * 1000));
                enemy.animator.SetBool("IsRun", false);
                enemy.StateMachine.ChangeState(enemy.IdleState);
                await Task.Delay((int)(3f * 1000));
                canMove = true;
        }
    }
}
