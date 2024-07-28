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
            if (!player.skillManager.thePowerOfTheMonarch.isCD)
            {
                player.skillManager.thePowerOfTheMonarch.Active();

                player.skillManager.thePowerOfTheMonarch.animator.Play("Active");
                WaitForCDSkill1();
                
            }
            else
            {
                player.playerStateMachine.ChangeState(player.playerIdleState);

            }
        }
        if (player.playerAction.Combat.Skill2.IsPressed())
        {
            if (!player.skillManager.criticalSlash.isCD)
            {
                if (player.targetArea.Enemy)
                {
                    player.RB.constraints = RigidbodyConstraints2D.FreezePositionY;
                    player.RB.MovePosition(player.transform.position + ((player.targetArea.Enemy.transform.position - player.transform.position).normalized * 3));
                    player.animator.SetBool("isDashing", true);
                    player.skillManager.criticalSlash.animator.Play("Active");
                    player.skillManager.criticalSlash.Active();
                    WaitForCDSkill2();
                }
                else
                {
                    player.playerStateMachine.ChangeState(player.playerIdleState);

                }
            }
            else
            {
                player.playerStateMachine.ChangeState(player.playerIdleState);

            }
        }
        if (player.playerAction.Combat.SpecialSkill.IsPressed())
        {
            if (!player.skillManager.rise.isCD)
            {
                player.skillManager.rise.gameObject.SetActive(true);
                player.skillManager.rise.spriteRenderer.enabled = true;
                player.skillManager.rise.animator.enabled = true;
                player.skillManager.rise.animator.Play("Rise");
                player.skillManager.rise.UseSkill();
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
        player.skillManager.thePowerOfTheMonarch.InActive();
        player.skillManager.criticalSlash.Deactive();
        player.animator.SetBool("isDashing", false);
        player.RB.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        AnimatorStateInfo stateInfoSkill1 = player.skillManager.thePowerOfTheMonarch.animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo stateInfoSkill2 = player.skillManager.criticalSlash.animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo specialSkill = player.skillManager.rise.animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfoSkill1.normalizedTime >= 1.0f)
        {
            player.playerStateMachine.ChangeState(player.playerIdleState);
        }

        if (stateInfoSkill2.normalizedTime >= 1.0f)
        {
            player.playerStateMachine.ChangeState(player.playerIdleState);
        }
        if (specialSkill.normalizedTime >= 1.0f)
        {
            player.playerStateMachine.ChangeState(player.playerIdleState);

        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    async void WaitForCDSkill1()
    {
        player.skillManager.thePowerOfTheMonarch.isCD = true;
        await Task.Delay((int)(player.skillManager.thePowerOfTheMonarch.cd * 1000));
        player.skillManager.thePowerOfTheMonarch.isCD = false;

    }
    async void WaitForCDSkill2()
    {
        player.skillManager.criticalSlash.isCD = true;
        await Task.Delay((int)(player.skillManager.criticalSlash.cd * 1000));
        player.skillManager.criticalSlash.isCD = false;
    }
    async void WaitForCDSpecialSkill()
    {
        player.skillManager.rise.isCD = true;
        await Task.Delay((int)(player.skillManager.rise.cd * 1000));
        player.skillManager.rise.isCD = false;
    }
}
