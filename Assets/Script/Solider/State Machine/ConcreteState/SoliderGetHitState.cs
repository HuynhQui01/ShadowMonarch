using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderGetHitState : SoliderState
{
    public SoliderGetHitState(Solider solider, SoliderStateMachine soliderStateMachine) : base(solider, soliderStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        solider.animator.SetTrigger("GetHit");
    }

    public override void ExitState()
    {
        base.ExitState();
        solider.takeHit = false;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate(); 
        if (solider.animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "GetHit"){
            solider.StateMachine.ChangeState(solider.IdleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
