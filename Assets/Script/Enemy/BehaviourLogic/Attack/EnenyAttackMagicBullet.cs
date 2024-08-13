using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Magic Bullet", menuName = "Enemy Logic/Attack Logic/Attack Magic Bullet")]
public class EnenyAttackMagicBullet : EnemyAttackSOBase
{
    // [SerializeField] public float bulletSpeed = 1f;
    // [SerializeField] GameObject bulletPrefab;
    bool canAttack = true;
    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        enemy.animator.SetTrigger("Attack");

        // rb.velocity = direction * bulletSpeed;
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

        AnimatorStateInfo stateInfo = enemy.animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1.0f)
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
        // if (canAttack)
        // {
        //     GameObject prefab = Instantiate(bulletPrefab, transform.position, transform.rotation);
        //     canAttack = false;
        //     Vector3 direction = (playerTransform.position - transform.position).normalized;
        //     BulletEnemy bullet = prefab.GetComponent<BulletEnemy>();

        //     bullet.RB.velocity = direction * bulletSpeed;
        //     BulletTime(bullet);

        // }
    }

    public override void DoPhysicUpdateLogic()
    {
        base.DoPhysicUpdateLogic();
    }

    // async void BulletTime(BulletEnemy bullet)
    // {
    //     await Task.Delay((int)(2f * 1000));
    //     Destroy(bullet.gameObject);
    //     canAttack = true;
    // }
}
