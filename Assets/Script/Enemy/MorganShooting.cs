using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MorganShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private int bulletCount = 5;
    [SerializeField] private float coneAngle = 45f;

    public void SpawnBulletsCone(Transform bossTransform, Transform playerTransform)
    {
        Vector2 direction = (playerTransform.localPosition - bossTransform.localPosition).normalized;

        float centralAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        float startAngle = centralAngle - coneAngle / 2f;
        float endAngle = centralAngle + coneAngle / 2f;

        for (int i = 0; i < bulletCount; i++)
        {

            float angle = Mathf.Lerp(startAngle, endAngle, i / (float)(bulletCount - 1));

            Vector2 bulletDirection = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            Vector2 spawnPosition = bossTransform.localPosition;

            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

            float rotationAngle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = bulletDirection * bulletSpeed;
            }

            BulletEnemy bulletEnemy = bullet.GetComponent<BulletEnemy>();
            if (bulletEnemy != null)
            {
                bulletEnemy.lifeTime = 3f;
            }
        }

    }

    public void TrainAttack(Transform bossTransform, Transform playerTransform){

    }

}
