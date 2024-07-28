using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class CriticalSlash : MonoBehaviour
{
    Player player;
    public Animator animator;
    public float damage = 10f;
    public float cd = 3f; 
    public bool isCD = false;
    public Sprite sprite;
    public string name = "Critical Slash";
    public string description = "Damage:\t10\nCD:\t3s\nCharacter will dash and hit any enemy on dash line.";

    // Start is called before the first frame update

    void Awake()
    {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Active()
    {
        gameObject.SetActive(true);
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            enemy.Damage(player.Damage + damage);
            enemy.hitEffect.gameObject.SetActive(true);
            enemy.hitEffect.animator.Play("HitEffect");
            enemy.hitEffect.CheckAnimation();   

            Debug.Log(enemy.CurrentHealth);
        }
    }

}
