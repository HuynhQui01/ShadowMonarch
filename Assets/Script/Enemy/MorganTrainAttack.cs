using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorganTrainAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 1f;
    [SerializeField] private float spawnOffset = 1.5f; 

    public void TrainAttack(Transform bossTransform, Transform playerTransform)
    {
        Vector2 direction = (playerTransform.position - bossTransform.position).normalized;

        Vector2 spawnPosition = (Vector2)bossTransform.position - (direction * spawnOffset);

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }

        BulletEnemy bulletEnemy = bullet.GetComponent<BulletEnemy>();
        if (bulletEnemy != null)
        {
            bulletEnemy.lifeTime = 3f; 
        }
    }
}
