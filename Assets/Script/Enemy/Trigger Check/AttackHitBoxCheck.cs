using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitBoxCheck : MonoBehaviour
{
    float damageAmout = 3f;

    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<Player>()){
            other.GetComponent<Player>().TakeDamage(damageAmout);
        }
    }
}
