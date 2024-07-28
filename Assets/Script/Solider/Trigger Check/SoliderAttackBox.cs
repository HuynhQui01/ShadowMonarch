using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderAttackBox : MonoBehaviour
{
    float damageAmout = 3f;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            other.GetComponent<Enemy>().Damage(damageAmout);
        }
    }
}
