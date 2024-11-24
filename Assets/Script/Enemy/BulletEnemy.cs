using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D RB;
    public float damge = 10f;
    [SerializeField] public float lifeTime = 5f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
    }

    void Start(){
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Player>().TakeDamage(damge);
        }
    }
}
