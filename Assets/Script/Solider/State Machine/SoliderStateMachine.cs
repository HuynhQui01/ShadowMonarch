using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderStateMachine 
{
    public SoliderState CurrentSoliderState { get; set; }

    public void Initialize(SoliderState startingState){
        CurrentSoliderState = startingState;
        CurrentSoliderState.EnterState();
    }

    public void ChangeState(SoliderState newState){
        Debug.Log("Solider Change from " + CurrentSoliderState.getNameState() + "to" + newState.getNameState());

        CurrentSoliderState.ExitState();
        CurrentSoliderState = newState;
        CurrentSoliderState.EnterState();
    }
}
