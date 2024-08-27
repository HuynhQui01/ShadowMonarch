using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Magic Bullet", menuName = "Enemy Logic/Attack Logic/Attack Magic Bullet")]
public class EnenyAttackMagicBullet : EnemyAttackSOBase
{
    bool canAttack = true;
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        if(canAttack){
            enemy.animator.SetTrigger("Attack");
            canAttack = false;
            AttackCD();
        }
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        enemy.MoveEnemy(Vector2.zero);

        if (enemy.takeHit)
        {
            enemy.StateMachine.ChangeState(enemy.GetHitState);
        }
        if(canAttack){
            enemy.animator.SetTrigger("Attack");
            canAttack = false;
            AttackCD();
        }

        AnimatorStateInfo stateInfo = enemy.animator.GetCurrentAnimatorStateInfo(0);
        float normalizedTime = Mathf.Repeat(stateInfo.normalizedTime, 1f);
        if (normalizedTime >= 0.9f)
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void DoPhysicUpdateLogic()
    {
        base.DoPhysicUpdateLogic();
    }

    async void AttackCD(){
        if (!canAttack)
        {
            await Task.Delay((int)(5f * 1000));
            canAttack = true;
        }
    }
}
