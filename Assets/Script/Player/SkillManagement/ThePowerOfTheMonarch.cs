using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePowerOfTheMonarch : MonoBehaviour
{
    public Animator animator;
    Player player;

    Vector2 attackOffset;
    public float cd = 5f;
    public bool isCD = false;
    public float damage = 10f;
    public Sprite sprite;
    public string name = "Power Of Monarch";
    public string description = "Damage:\t10\nCD:\t5s\nCharacter will create a huge hand and attack enemy.";
    // Start is called before the first frame update

    void Awake(){
        player = FindObjectOfType<Player>();
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        attackOffset = transform.localPosition;
        gameObject.SetActive(false);
    }

    public void Active(){
        gameObject.SetActive(true);
    }
    public void InActive(){
        gameObject.SetActive(false);
    }

    public void SkillDirection()
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
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            enemy.Damage(player.Damage + damage);
            Debug.Log(enemy.CurrentHealth);
        }
    }
}
