using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Qian : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    
    public float bulletSpeed = 3f;

    public void CreateBullet()
    {
        Transform playerTransform = GameObject.Find("Player test").transform;
        GameObject prefab = Instantiate(bulletPrefab, transform.position, transform.rotation);
        
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        BulletEnemy bullet = prefab.GetComponent<BulletEnemy>();

        this.CheckForLeftOrRightFacing(direction * bulletSpeed);
        bullet.RB.velocity = direction * bulletSpeed;
        BulletTime(bullet);
    }

    async void BulletTime(BulletEnemy bullet)
    {
        await Task.Delay((int)(2f * 1000));
        Destroy(bullet.gameObject);
        
    }
}
