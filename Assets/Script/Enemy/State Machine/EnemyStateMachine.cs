using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    public EnemyState CurrentEnemyState { get; set; }

    public void Initialize(EnemyState startingState){
        CurrentEnemyState = startingState;
        CurrentEnemyState.EnterState();
    }

    public void ChangeState(EnemyState newState){
        // Debug.Log("Change from " + CurrentEnemyState.getNameState() + "to " + newState.getNameState());
        CurrentEnemyState.ExitState();
        CurrentEnemyState = newState;
        CurrentEnemyState.EnterState();
    }
}
