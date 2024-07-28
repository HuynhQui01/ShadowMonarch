using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.animator.SetTrigger("Attack");
    }

    public override void ExitState()
    {
        base.ExitState();
        player.animator.SetBool("KeepingAttack", false);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        
        if(player.playerAction.Combat.Attack.IsInProgress()){
            player.animator.SetBool("KeepingAttack", true);
        }
        if(!player.playerAction.Combat.Attack.IsPressed() || !player.playerAction.Combat.Attack.IsInProgress()){
            player.playerStateMachine.ChangeState(player.playerIdleState);
        } 
        if(player.playerAction.Combat.Dash.IsPressed()){
            player.playerStateMachine.ChangeState(player.playerDashState);
        }
        if(player.playerAction.Combat.Skill1.IsPressed()){
            player.playerStateMachine.ChangeState(player.playerUseSkillState);
        }
        if(player.playerAction.Combat.Skill2.IsPressed()){

        }
        if(player.playerAction.Combat.SpecialSkill.IsPressed()){
            
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
