using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Boss Witch Idel", menuName = "Enemy Logic/Idel Logic/ Boss Witch Idel")]
public class BossWitchIdel : EnemyIdelSOBase
{
    bool isChangeState = false;
    float timer = 0.0f;

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);

    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        WaitForChangeState();
        Debug.Log("In Idle State");
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();

    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        if (enemy.IsAggroed)
        {
            enemy.StateMachine.ChangeState(enemy.MoveState);
        }
    }

    public override void DoPhysicUpdateLogic()
    {
        base.DoPhysicUpdateLogic();
    }

    async void WaitForChangeState()
    {
        await Task.Delay((int)0.5f * 1000);
        isChangeState = true;
    }
}
