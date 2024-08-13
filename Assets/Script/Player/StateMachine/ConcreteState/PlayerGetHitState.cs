using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetHitState : PlayerState
{
    public PlayerGetHitState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.animator.SetTrigger("GetHit");
        player.canMove = false;
    }
    public override void ExitState() {
        player.canMove = true;
     }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        AnimatorStateInfo info = player.animator.GetCurrentAnimatorStateInfo(0);
        if(info.normalizedTime >= 0.5f){
            playerStateMachine.ChangeState(player.playerIdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
