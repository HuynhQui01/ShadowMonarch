using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Health
    {
        set
        {
            if (value < health)
            {
                print("aaa");
                animator.SetTrigger("GetHit");
            }
            health = value;
            if (Health <= 0)
            {
                print("Dead");
                animator.SetBool("Dead", true);
                canMove = false;
                collider2D.enabled = false;
            }
        }
        get { return health; }
    }
    public float Damage { get => damage; set => damage = value; }
    public float Armor { get => armor; set => armor = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    float health = 10;
    float damage = 2;
    float armor = 0;
    float moveSpeed = 100f;

    Rigidbody2D rb;

    Collider2D collider2D;
    // [SerializeField] private ParticleSystem damgeParticleSystem;
    // private ParticleSystem particleSystemInstance;
    [SerializeField] private OnHitEffect onHitEffect;

    public bool canMove = true;



    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
    }

    void Start()
    {
        onHitEffect = GetComponent<OnHitEffect>();
        onHitEffect.enabled = false;
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damage)
    {
        onHitEffect.enabled = true;
        // SpawnDamgePartical();

        canMove = false;
        health -= damage;
        print(health);
        animator.SetTrigger("GetHit");
        canMove = true;
            StartCoroutine(EndDamgeRountine());


    }

    public void TakeDamage(float damage, Vector2 knockback)
    {
        canMove = false;
        health -= damage;
        print(health);
        animator.SetTrigger("GetHit");
        canMove = true;
        rb.AddForce(knockback);

    }

    IEnumerator EndDamgeRountine(){
        yield return new WaitForSeconds(0.1f);
        onHitEffect.enabled = false;
        // yield return new WaitForSeconds(0.5f);
        // animator.SetBool("GetHit", false);
        // canMove = true;
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            animator.SetBool("Running", canMove);
        }
        else
        {
            animator.SetBool("Running", canMove);
        }
        if (Health <= 0)
        {
            animator.SetBool("Dead", true);
            canMove = false;
            collider2D.enabled = false;
            // Dead();
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    // void SpawnDamgePartical(){
    //     print("Spawning");
    //     particleSystemInstance = Instantiate(damgeParticleSystem, transform.position, Quaternion.identity);
    // }

}
