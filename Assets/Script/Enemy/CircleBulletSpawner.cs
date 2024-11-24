using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CircleBulletSpawner : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] private int bulletCount = 12;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float spawnRadius = 1f;
    [SerializeField] private Rigidbody2D rigidbody2D;

    [SerializeField] private bool randomizeSpeed = true; 
    [SerializeField] private bool randomizeAngle = true; 

    [SerializeField] private float minBulletSpeed = 3f; 
    [SerializeField] private float maxBulletSpeed = 7f; 
    [SerializeField] private float bulletSpacing = 0.5f;

    public async void SpawnBullets(Vector2 position)
    {
        var randomAttack = Random.Range(1, 4);
        for (int j = 0; j <= randomAttack; j++)
        {
            await Task.Delay(500);

            for (int i = 0; i < bulletCount; i++)
            {
                float angle = i * (360f / bulletCount);
                if (randomizeAngle)
                {
                    angle += Random.Range(-15f, 15f);
                }

                Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

                GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    float speed = randomizeSpeed ? Random.Range(minBulletSpeed, maxBulletSpeed) : bulletSpeed;
                    rb.velocity = direction * speed;
                }

                BulletEnemy bulletEnemy = bullet.GetComponent<BulletEnemy>();
                if (bulletEnemy != null)
                {
                    bulletEnemy.lifeTime = 3f;
                }
            }
        }
    }
    public async void SpawnHorizontalLine(Vector2 position, Vector2 targetPosition)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Vector2 spawnPosition = new Vector2(position.x , (position.y - 2) + i * bulletSpacing);

            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float speed = randomizeSpeed ? Random.Range(minBulletSpeed, maxBulletSpeed) : bulletSpeed;
                rb.velocity = (targetPosition - position).normalized * speed;  
            }

            BulletEnemy bulletEnemy = bullet.GetComponent<BulletEnemy>();
            if (bulletEnemy != null)
            {
                bulletEnemy.lifeTime = 3f;
            }

            await Task.Delay(100); 
        }
    }

    public async void SpawnBulletsInward(Vector2 position)
{
    var randomAttack = Random.Range(1, 4);
    for (int j = 0; j <= randomAttack; j++)
    {
        await Task.Delay(500);

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (360f / bulletCount);
            if (randomizeAngle)
            {
                angle += Random.Range(-15f, 15f);
            }

            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            float outerRadius = spawnRadius * 7f; 
            Vector2 spawnPosition = position + direction * outerRadius;

            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float speed = randomizeSpeed ? Random.Range(minBulletSpeed, maxBulletSpeed) : bulletSpeed;
                rb.velocity = -direction * speed; 
            }

            BulletEnemy bulletEnemy = bullet.GetComponent<BulletEnemy>();
            if (bulletEnemy != null)
            {
                bulletEnemy.lifeTime = 3f;
            }
        }
    }
}

}
