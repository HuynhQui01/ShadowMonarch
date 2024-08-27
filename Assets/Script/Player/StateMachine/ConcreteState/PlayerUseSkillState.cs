using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerUseSkillState : PlayerState
{
    public PlayerUseSkillState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        if (player.playerAction.Combat.Skill1.IsPressed())
        {
            if (!player.skillManager.skillsEquipped[0].IsCD)
            {
                player.skillManager.skillsEquipped[0].Active();
                WaitForCDSkill1();
            }
            else
            {
                player.playerStateMachine.ChangeState(player.playerIdleState);

            }
        }
        if (player.playerAction.Combat.Skill2.IsPressed())
        {
            if (!player.skillManager.skillsEquipped[1].IsCD)
            {
                player.skillManager.skillsEquipped[1].Active();

                WaitForCDSkill2();
            }
            else
            {
                player.playerStateMachine.ChangeState(player.playerIdleState);

            }
        }
        if (player.playerAction.Combat.SpecialSkill.IsPressed())
        {
            if (!player.skillManager.skillsEquipped[2].IsCD)
            {
                player.skillManager.skillsEquipped[2].Active();
                WaitForCDSpecialSkill();

            }
            else
            {
                player.playerStateMachine.ChangeState(player.playerIdleState);

            }

        }
    }

    public override void ExitState()
    {
        base.ExitState();
        player.animator.SetBool("isDashing", false);
        player.RB.constraints = RigidbodyConstraints2D.FreezeRotation;
        player.gameObject.layer = 0;



    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        AnimatorStateInfo stateInfoSkill1 = player.skillManager.skillsEquipped[0].GetAnimatorStateInfo();
        AnimatorStateInfo stateInfoSkill2 = player.skillManager.skillsEquipped[1].GetAnimatorStateInfo();
        AnimatorStateInfo specialSkill = player.skillManager.skillsEquipped[2].GetAnimatorStateInfo();

        if (stateInfoSkill1.normalizedTime >= 1.0f)
        {
            player.skillManager.skillsEquipped[0].DeActive();
            player.playerStateMachine.ChangeState(player.playerIdleState);
        }

        if (stateInfoSkill2.normalizedTime >= 1.0f)
        {
            player.skillManager.skillsEquipped[1].DeActive();

            player.playerStateMachine.ChangeState(player.playerIdleState);
        }
        if (specialSkill.normalizedTime >= 1.0f)
        {
            player.skillManager.skillsEquipped[2].DeActive();

            player.playerStateMachine.ChangeState(player.playerIdleState);

        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    async void WaitForCDSkill1()
    {
        player.skillManager.skillsEquipped[0].IsCD = true;
        await Task.Delay((int)(player.skillManager.skillsEquipped[0].CD * 1000));
        player.skillManager.skillsEquipped[0].IsCD = false;

    }
    async void WaitForCDSkill2()
    {
        player.skillManager.skillsEquipped[1].IsCD = true;
        await Task.Delay((int)(player.skillManager.skillsEquipped[1].CD * 1000));
        player.skillManager.skillsEquipped[1].IsCD = false;
    }
    async void WaitForCDSpecialSkill()
    {
        player.skillManager.skillsEquipped[2].IsCD = true;
        await Task.Delay((int)(player.skillManager.skillsEquipped[2].CD * 1000));
        player.skillManager.skillsEquipped[1].IsCD = false;
    }
}
