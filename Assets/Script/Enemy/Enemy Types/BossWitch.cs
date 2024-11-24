using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossWitch : Enemy
{
    public GameObject magicBullet;
    public bool isTransformed;
    public CircleBulletSpawner circleBulletSpawner;
        
    public void ChangePhase(){
        Debug.LogWarning("Changing");
        if(this.CurrentHealth <= 0){
            this.animator.SetBool("IsTransform",true);
        }
    }

    public override void Damage(float damageAmout)
    {
        Debug.Log("Damage boss");
        CurrentHealth -= damageAmout;
            takeHit = true;
            healthTextPrefab.SetText(damageAmout);
            RectTransform text = Instantiate(healthTextPrefab).GetComponent<RectTransform>();
            text.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            Canvas canvas = GameObject.FindAnyObjectByType<Canvas>();
            text.SetParent(canvas.transform);
        if(CurrentHealth <= 0){
            ChangePhase();
        }
    }

    public void CircleAttackBullet(){
        circleBulletSpawner.SpawnBullets(this.transform.position);
    }

    public void HorizontalAttackBullet(){
        circleBulletSpawner.SpawnHorizontalLine(this.transform.position, this.player.RB.position);
    }

    public void CircleAttackBulletInward(){
        circleBulletSpawner.SpawnBulletsInward(this.transform.position);

    }
}
