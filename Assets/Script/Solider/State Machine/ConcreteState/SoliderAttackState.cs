using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderAttackState : SoliderState
{

    public SoliderAttackState(Solider solider, SoliderStateMachine soliderStateMachine) : base(solider, soliderStateMachine)
    {

    }

    public override void EnterState()
    {
        
        base.EnterState();
        solider.SoliderAttackBaseInstance.DoEnterLogic();
    }
    public override void ExitState()
    {
        base.ExitState();
        solider.SoliderAttackBaseInstance.DoExitLogic();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        solider.SoliderAttackBaseInstance.DoFrameUpdateLogic();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    
}
