using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderDeadState : SoliderState
{
    public SoliderDeadState(Solider solider, SoliderStateMachine soliderStateMachine) : base(solider, soliderStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        solider.animator.SetBool("IsDead", true);
        AnimatorStateInfo stateInfo = solider.animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 0.4f)
        {
            solider.Die();
        }

    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
