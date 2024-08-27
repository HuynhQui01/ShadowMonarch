using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrikingDistanceCheck : MonoBehaviour
{
    Enemy enemy;

    void Awake(){
        enemy = GetComponentInParent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            enemy.SetStrikingDistanceBool(true);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            enemy.SetStrikingDistanceBool(false);
        }
    }
}
