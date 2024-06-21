using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitBoxCheck : MonoBehaviour
{
    float damageAmout = 3f;

    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<PlayerController>()){
            other.GetComponent<PlayerController>().Damaged(damageAmout);
        }
    }
}
