using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    Vector2 movement;   
    float moveSpeed = 2f;
    
    public PlayerMoveState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.animator.SetBool("Running", true);
    }

    public override void ExitState()
    {
        base.ExitState();
        player.animator.SetBool("Running", false);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        movement = player.playerAction.Movement.Move.ReadValue<Vector2>();
        player.RB.MovePosition(player.RB.position + movement * (moveSpeed * Time.fixedDeltaTime));
        player.CheckForLeftOrRightFacing(movement);
        if(player.movementInput == Vector2.zero){
            player.playerStateMachine.ChangeState(player.playerIdleState);
        }
        if(player.playerAction.Combat.Attack.IsPressed() || player.playerAction.Combat.Attack.IsInProgress()){
            player.playerStateMachine.ChangeState(player.playerAttackState);
        }
        if(player.playerAction.Combat.Dash.IsPressed()){
            player.playerStateMachine.ChangeState(player.playerDashState);
        }
        if(player.playerAction.Combat.Skill1.IsPressed()){
            player.playerStateMachine.ChangeState(player.playerUseSkillState);
        }
        if(player.playerAction.Combat.Skill2.IsPressed()){
            player.playerStateMachine.ChangeState(player.playerUseSkillState);
        }
        if(player.playerAction.Combat.SpecialSkill.IsPressed()){
            
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
