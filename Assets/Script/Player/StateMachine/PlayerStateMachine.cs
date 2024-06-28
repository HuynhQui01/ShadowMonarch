using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerState currentPlayerState;

    public void Initialize(PlayerState startingState){
        currentPlayerState = startingState;
        currentPlayerState.EnterState();
    }

    public void ChangeState(PlayerState newState){
        // Debug.Log("Change from " + currentPlayerState.getNameState() + "to" + newState.getNameState());
        currentPlayerState.ExitState();
        currentPlayerState = newState;
        currentPlayerState.EnterState();
    }
}
