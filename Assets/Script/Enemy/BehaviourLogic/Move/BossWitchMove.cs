using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Move-Direct Move", menuName = "Enemy Logic/Move Logic/Boss witch move")]

public class BossWitchMove : EnemyMoveSOBase
{
    [SerializeField] private float movementSpeed = 0.5f;

    bool canChangeState = false;
    float timer = 0;

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        enemy.animator.SetBool("IsRun", true);
        WaitForChangeState();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        timer += Time.deltaTime;

        if (enemy.takeHit)
        {
            enemy.StateMachine.ChangeState(enemy.GetHitState);
        }

        if (timer >= 5f)
        {
            if (enemy.IsWithinStrikingDistance)
            {
                timer = 0;
                Debug.Log("Change to AttackState");
                enemy.StateMachine.ChangeState(enemy.AttackState);
                timer = 0;
                return;
            }
        }

        Vector2 moveDir = (playerTransform.position - enemy.transform.position).normalized;
        enemy.MoveEnemy(moveDir * movementSpeed);
    }

    public override void DoPhysicUpdateLogic()
    {
        base.DoPhysicUpdateLogic();
    }

    async void WaitForChangeState()
    {
        await Task.Delay((int)0.5f * 1000);
        canChangeState = true;
    }
}
