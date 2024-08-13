using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class CriticalSlash : MonoBehaviour, ISkill
{
    public float CD { get; set; } = 3f;
    public bool IsCD { get; set;} = false;
    public float BaseDamage { get; set; } = 6f;
    public float LevelUpDamgePlus { get; set; } = 1.5f;
    public int Level { get; set; } = 0;
    public bool IsUnlocked { get; set; } = true;
    public bool IsEquipped { get; set; } = true;
    [field: SerializeField] public Sprite sprite { get; set; }

    public float curDamge;
    Player player;
    public Animator animator;
    public string name = "Critical Slash";
    public string description;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {IsEquipped = true;
        curDamge = BaseDamage;
        description = "Damage:\t "+ curDamge.ToString() + "+ player damage/3"+"\nCD:\t3s\nCharacter will dash and hit any enemy on dash line.";
        gameObject.SetActive(false);
    }

    public void Active()
    {
        gameObject.SetActive(true);
        animator.Play("Active");
    }

    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            enemy.Damage((player.Damage/3) + curDamge);
            enemy.hitEffect.gameObject.SetActive(true);
            enemy.hitEffect.animator.Play("HitEffect");
            enemy.hitEffect.CheckAnimation();   

            Debug.Log(enemy.CurrentHealth);
        }
    }

    public void DeActive()
    {
        gameObject.SetActive(false);
        
    }

    public AnimatorStateInfo GetAnimatorStateInfo(){
        AnimatorStateInfo animatorState = animator.GetCurrentAnimatorStateInfo(0);
        return animatorState;
    }
}