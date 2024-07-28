using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderIdleState : SoliderState
{
    
    public SoliderIdleState(Solider solider, SoliderStateMachine soliderStateMachine) : base(solider, soliderStateMachine)
    {
    }

    public override void EnterState(){
        base.EnterState();
        solider.SoliderIdleBaseInstance.DoEnterLogic();
    }
    public override void ExitState(){
        base.ExitState();
        solider.SoliderIdleBaseInstance.DoExitLogic();
    }
    public override void FrameUpdate(){
        base.FrameUpdate();
        solider.SoliderIdleBaseInstance.DoFrameUpdateLogic();
        
    }
    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
        solider.SoliderIdleBaseInstance.DoPhysicUpdateLogic();
    }
   

    
}
