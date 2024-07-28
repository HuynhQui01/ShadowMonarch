using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderAggroCheck : MonoBehaviour
{
    Solider solider;

    void Awake(){

        solider = GetComponentInParent<Solider>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy"){
            solider.SetAggroStatus(true);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            solider.SetAggroStatus(false);
        }
    }
}
