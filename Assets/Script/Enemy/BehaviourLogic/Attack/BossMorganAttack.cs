using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Boss Morgan Attack", menuName = "Enemy Logic/Attack Logic/Boss Morgan Attack")]

public class BossMorganAttack : EnemyAttackSOBase
{
    AnimatorStateInfo info;
    float cooldownTimer = 0f;
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        int random = Random.Range(1, 5);
        enemy.animator.SetBool("IsRun", false);
        ChooseAtack(random);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        enemy.animator.SetBool("IsRun", true);

    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (info.normalizedTime >= 0.9 && cooldownTimer <= 0)
        {
            Debug.Log("Change to Move");
            enemy.StateMachine.ChangeState(enemy.MoveState);
        }
    }

    public override void DoPhysicUpdateLogic()
    {
        base.DoPhysicUpdateLogic();
    }

    void ChooseAtack(int number)
    {
        
        switch (number)
        {
            case 1:
                SetCD(1f);
                enemy.RB.velocity = Vector2.zero;
                enemy.animator.SetTrigger("NormalAttack");
                info = enemy.animator.GetCurrentAnimatorStateInfo(0);

                break;
            case 2:
                SetCD(4f);
                enemy.RB.velocity = Vector2.zero;
                enemy.animator.SetTrigger("Shotting");
                info = enemy.animator.GetCurrentAnimatorStateInfo(0);

                break;
            case 3:
                SetCD(3f);
                enemy.RB.velocity = Vector2.zero;
                enemy.animator.SetTrigger("EarthquakeAttack");
                info = enemy.animator.GetCurrentAnimatorStateInfo(0);

                break;
            case 4:
                SetCD(2f);
                enemy.RB.velocity = Vector2.zero;
                enemy.animator.SetTrigger("TrainAttack");
                info = enemy.animator.GetCurrentAnimatorStateInfo(0);

                break;
            default:
                break;
        }
    }

    void SetCD(float duration)
    {
        cooldownTimer = duration;
    }

}
