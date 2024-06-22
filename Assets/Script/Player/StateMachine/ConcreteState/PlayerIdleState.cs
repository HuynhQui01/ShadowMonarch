using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerState
{
    
    public PlayerIdleState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(player.movementInput != Vector2.zero){
            playerStateMachine.ChangeState(player.playerMovementState);
        }
        if(player.playerAction.Combat.Attack.IsPressed() || player.playerAction.Combat.Attack.IsInProgress()){
            player.playerStateMachine.ChangeState(player.playerAttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    
}
