using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Follow Player", menuName = "Solider Logic/Idle Logic/ Follow Player")]
public class SoliderFollowPlayer : SoliderIdleSOBase
{
    [SerializeField] private float MovementSpeed = 1f;
    [SerializeField] private float StopDistance = 0.5f;
    [SerializeField] private Vector3 RandomPositionAroundPlayer;


    public override void Initialize(GameObject gameObject, Solider Solider)
    {
        base.Initialize(gameObject, Solider);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        solider.animator.SetBool("IsRun", true);

    }
    public override void DoExitLogic()
    {
        base.DoExitLogic();
        solider.animator.SetBool("IsRun", false);

    }
    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        if (solider.takeHit)
        {
            solider.StateMachine.ChangeState(solider.GetHitState);
        }
        // if (solider.IsAggroed)
        // {
        //     solider.StateMachine.ChangeState(solider.MoveState);
        // }
        Vector3 targetPosition = playerTransform.position - RandomPositionAroundPlayer;
        if (solider.soliderDetectZone.enemies[0])
        {
            solider.StateMachine.ChangeState(solider.MoveState);
        }
        // if(Vector3.Distance(solider.transform.position, targetPosition) > 1.5f){
        //     solider.RB.MovePosition(targetPosition);
        // }
        if (Vector3.Distance(solider.transform.position, targetPosition) > StopDistance)
        {
            solider.animator.SetBool("IsRun", true);
            solider.MoveSolider((targetPosition - solider.transform.position).normalized * MovementSpeed);
        }
        else
        {
            solider.MoveSolider(Vector2.zero);
            solider.animator.SetBool("IsRun", false);
        }

    }
    public override void DoPhysicUpdateLogic()
    {
        base.DoPhysicUpdateLogic();
    }


}
