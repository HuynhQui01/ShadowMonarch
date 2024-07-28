using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack-With-Weapon", menuName = "Solider Logic/Attack Logic/Attack With Weapon")]
public class SoliderAttackWithWeapon : SoliderAttackSOBase
{
    public override void Initialize(GameObject gameObject, Solider solider)
    {
        base.Initialize(gameObject, solider);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public override void DoEnterLogic(){
        base.DoEnterLogic();
        solider.MoveSolider(Vector2.zero);
        solider.animator.SetTrigger("Attack");
    }

    public override void DoExitLogic(){
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic(){
        base.DoFrameUpdateLogic();
        if(solider.takeHit){
            solider.StateMachine.ChangeState(solider.GetHitState);
        }

        AnimatorStateInfo stateInfo = solider.animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1.0f )
        {
            solider.StateMachine.ChangeState(solider.IdleState);
        }
        
    }

    public override void DoPhysicUpdateLogic(){
        base.DoPhysicUpdateLogic();
    }

    
}
