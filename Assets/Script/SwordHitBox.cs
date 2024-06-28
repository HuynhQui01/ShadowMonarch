using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    PlayerAction playerAction;
    Player player;
    public float knockBackForce = 5000f;

    Vector2 attackOffset;
    public float damage = 2f;


    void Awake()
    {
        player = FindObjectOfType<Player>();
        playerAction = new PlayerAction();
        
    }


    void OnEnable()
    {
        playerAction.Enable();
    }

    void Start()
    {
        
        attackOffset = transform.localPosition;
    }

    void FixedUpdate()
    {

    }

    void Update()
    {
        // EndAttack();
    }

    public void WeaponDirection()
    {
        if (player.IsFacingRight)
        {
            transform.localPosition = new Vector3(attackOffset.x * -1, attackOffset.y);
        }
        else
        {
            transform.localPosition = attackOffset;
        }
    }

    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
                Vector2 direction = (Vector2) (col.gameObject.transform.position - parentPosition).normalized;
                Vector2 knockBack = direction * knockBackForce;
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            enemy.Damage(player.Damage + damage);
            Debug.Log(enemy.CurrentHealth);
        }
    }

}
