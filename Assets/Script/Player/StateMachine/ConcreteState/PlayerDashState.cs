using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    bool isDashing = false;
    Vector2 movement;
    float dashSpeed = 4f;
    float moveSpeed = 2f;
    public PlayerDashState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        if (!isDashing)
        {
            player.dashEffect.enabled = true;
            player.dashEffect.CreateEffect();
            isDashing = true;
            player.animator.SetBool("isDashing", isDashing);
            movement = player.playerAction.Movement.Move.ReadValue<Vector2>();
            player.gameObject.layer = 5;

            player.RB.velocity = movement * moveSpeed * dashSpeed;
            EndDashRountine();
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (!player.playerAction.Combat.Dash.IsPressed())
        {
            player.playerStateMachine.ChangeState(player.playerIdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    async void EndDashRountine()
    {

        float dashTime = 0.2f;
        float dashCD = 0.25f;
        await Task.Delay((int)(dashTime * 1000));
        player.dashEffect.enabled = false;
        await Task.Delay((int)(dashCD * 1000));
        isDashing = false;
        player.animator.SetBool("isDashing", isDashing);
        player.gameObject.layer = 0;

    }
}
