using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderMoveState : SoliderState
{
        public SoliderMoveState(Solider solider, SoliderStateMachine soliderStateMachine) : base(solider, soliderStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        solider.SoliderMoveBaseInstance.DoEnterLogic();
    }
    public override void ExitState()
    {
        base.ExitState();
        solider.SoliderMoveBaseInstance.DoExitLogic();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        solider.SoliderMoveBaseInstance.DoFrameUpdateLogic();
        
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        solider.SoliderMoveBaseInstance.DoPhysicUpdateLogic();
    }
}
