using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderState
{
    protected Solider solider;
    protected SoliderStateMachine soliderStateMachine;
    public SoliderState(Solider solider, SoliderStateMachine soliderStateMachine){
        this.solider = solider;
        this.soliderStateMachine = soliderStateMachine;
    }

    public string getNameState(){
        return this.GetType().Name;
    }

    public virtual void EnterState(){}
    public virtual void ExitState(){}
    public virtual void FrameUpdate(){}
    public virtual void PhysicsUpdate(){}
}
