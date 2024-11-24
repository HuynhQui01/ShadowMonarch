using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.MoveSpeed = 0f;
        player.canMove = false;
        player.animator.SetTrigger("Attack");
    }

    public override void ExitState()
    {
        base.ExitState();
        player.animator.SetBool("KeepingAttack", false);
        player.MoveSpeed = 2f;

    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        AnimatorStateInfo info = player.animator.GetCurrentAnimatorStateInfo(0);
        if (player.playerAction.Combat.Attack.IsInProgress())
        {
            player.animator.SetBool("KeepingAttack", true);
        }
        if (!player.playerAction.Combat.Attack.IsPressed() || !player.playerAction.Combat.Attack.IsInProgress())
        {
            player.animator.SetBool("KeepingAttack", false);

            if (info.normalizedTime >= 0.9f)
            {
                WaitAnimationEnd();
            }
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

    async void WaitAnimationEnd()
    {
        await Task.Delay((int)(0.18f * 1000));
        playerStateMachine.ChangeState(player.playerIdleState);
    }
}
