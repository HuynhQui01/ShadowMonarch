using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chase Enemy", menuName = "Solider Logic/Move Logic/ Chase Enemy")]
public class SoliderChaseEnemy : SoliderMoveSOBase
{
    [SerializeField] private float MovementSpeed = 1f;

    public override void Initialize(GameObject gameObject, Solider Solider)
    {
        base.Initialize(gameObject, Solider);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }
    public override void DoExitLogic()
    {
        base.DoExitLogic();

    }
    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        if (Solider.soliderDetectZone.enemies[0])
        {
            if (Solider.soliderDetectZone.enemies[0].isDead)
            {
                Solider.MoveSolider((Solider.soliderDetectZone.enemies[0].transform.position - Solider.transform.position).normalized * MovementSpeed);
            }
            else
            {
                Solider.StateMachine.ChangeState(Solider.IdleState);
            }
        }
        else
        {
            Solider.StateMachine.ChangeState(Solider.IdleState);
        }
        if (Solider.IsWithinStrikingDistance)
        {
            Solider.StateMachine.ChangeState(Solider.AttackState);
        }
    }
    public override void DoPhysicUpdateLogic()
    {
        base.DoPhysicUpdateLogic();
    }
}
