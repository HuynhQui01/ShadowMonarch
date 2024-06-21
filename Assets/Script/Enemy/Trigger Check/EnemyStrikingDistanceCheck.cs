using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrikingDistanceCheck : MonoBehaviour
{
    // public GameObject PlayerTarget { get; set; }
    Enemy enemy;

    void Awake(){
        // PlayerTarget = GameObject.FindGameObjectsWithTag("Player")[0];

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
