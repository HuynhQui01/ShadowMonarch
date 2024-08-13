using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Vampire : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    public float bulletSpeed = 1f;

    public void CreateBullet()
    {
        Transform playerTransform = GameObject.Find("Player test").transform;
        GameObject prefab = Instantiate(bulletPrefab, transform.position, transform.rotation);
        
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        BulletEnemy bullet = prefab.GetComponent<BulletEnemy>();

        bullet.RB.velocity = direction * bulletSpeed;
        BulletTime(bullet);
    }

    async void BulletTime(BulletEnemy bullet)
    {
        await Task.Delay((int)(2f * 1000));
        Destroy(bullet.gameObject);
        
    }
}
