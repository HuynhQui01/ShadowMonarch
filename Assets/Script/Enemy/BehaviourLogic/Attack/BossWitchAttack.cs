using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Boss Witch Attack", menuName = "Enemy Logic/Attack Logic/Boss Witch Attack")]
public class BossWitchAttack : EnemyAttackSOBase
{

    bool isTransformed = false;
    bool isCD = false;
    AnimatorStateInfo info;
    Vector2 v;

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        Debug.Log("Attack");
        isTransformed = enemy.animator.GetBool("IsTransform");
        v = (enemy.transform.localPosition - playerTransform.localPosition).normalized * 1.5f;
        if (!isTransformed && !isCD)
        {
            enemy.animator.SetTrigger("NormalAttack");

            Debug.Log("NormalAttack");
            isCD = true;
            SetCD();
        }
        if (isTransformed && !isCD)
        {
            int random = Random.Range(1, 7);
            isCD = true;
            ChooseAttack(random);
        }

    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        info = enemy.animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log(info.normalizedTime);
        if (info.normalizedTime >= 0.8f)
        {
            Debug.Log("Idle");
            enemy.StateMachine.ChangeState(enemy.MoveState);
        }
    }

    public override void DoPhysicUpdateLogic()
    {
        base.DoPhysicUpdateLogic();
    }

    void ChooseAttack(int number)
    {
        switch (number)
        {
            case 1:
                StopMove();
                enemy.animator.SetTrigger("Attack1");
                info = enemy.animator.GetCurrentAnimatorStateInfo(0);
                break;
            case 2:
                StopMove();
                enemy.animator.SetTrigger("Attack2");

                info = enemy.animator.GetCurrentAnimatorStateInfo(0);
                break;
            case 3:
                StopMove();

                enemy.animator.SetTrigger("Attack3");

                info = enemy.animator.GetCurrentAnimatorStateInfo(0);
                break;
            case 4:
                StopMove();

                enemy.animator.SetTrigger("Attack4");

                info = enemy.animator.GetCurrentAnimatorStateInfo(0);
                break;
            case 5:
                StopMove();

                enemy.animator.SetTrigger("MagicAttack1");

                info = enemy.animator.GetCurrentAnimatorStateInfo(0);
                break;
            case 6:
                StopMove();

                enemy.animator.SetTrigger("MagicAttack2");

                info = enemy.animator.GetCurrentAnimatorStateInfo(0);
                break;
            case 7:
                StopMove();

                enemy.animator.SetTrigger("MagicAttack3");

                info = enemy.animator.GetCurrentAnimatorStateInfo(0);
                break;
        }
        SetCD();
    }

    void StopMove(){
        enemy.RB.velocity = v;
    }

    async void SetCD()
    {

        await Task.Delay((int)0.5f * 1000);
        isCD = false;
    }

}
