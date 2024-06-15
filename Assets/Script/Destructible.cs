using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.GetComponent<SwordHitBox>()){
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);    
        }
    }
}
