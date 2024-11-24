using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    Vector2 movement;

    public PlayerMoveState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.animator.SetBool("Running", true);
        player.canMove = true;
    }

    public override void ExitState()
    {
        base.ExitState();
        player.animator.SetBool("Running", false);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (player.canMove)
        {
            movement = player.playerAction.Movement.Move.ReadValue<Vector2>();
            player.RB.MovePosition(player.RB.position + movement * (player.MoveSpeed * Time.fixedDeltaTime));
            player.CheckForLeftOrRightFacing(movement);
        }
        else
        {
            player.playerStateMachine.ChangeState(player.playerIdleState);
        }
        if (player.movementInput == Vector2.zero)
        {
            player.playerStateMachine.ChangeState(player.playerIdleState);
        }
        if (player.playerAction.Combat.Attack.IsPressed() || player.playerAction.Combat.Attack.IsInProgress())
        {
            player.playerStateMachine.ChangeState(player.playerAttackState);
        }
        if (player.playerAction.Combat.Dash.IsPressed())
        {
            player.playerStateMachine.ChangeState(player.playerDashState);
        }
        if (player.playerAction.Combat.Skill1.IsPressed())
        {
            player.playerStateMachine.ChangeState(player.playerUseSkillState);
        }
        if (player.playerAction.Combat.Skill2.IsPressed())
        {
            player.playerStateMachine.ChangeState(player.playerUseSkillState);
        }
        if (player.playerAction.Combat.SpecialSkill.IsPressed())
        {
            player.playerStateMachine.ChangeState(player.playerUseSkillState);
        }
        if (player.playerAction.Evolve.Evolve.IsPressed())
        {
            player.playerStateMachine.ChangeState(player.playerUseSkillState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
