using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePowerOfTheMonarch : MonoBehaviour, ISkill
{
    public Animator animator;
    Player player;
   
    [field: SerializeField] public Sprite sprite { get; set; }
    public string name = "Power Of Monarch";
    public string description = "Damage:\t10\nCD:\t5s\nCharacter will create a huge hand and attack enemy.";

    public float BaseDamage { get; set; } = 5f;
    public float LevelUpDamgePlus { get; set; } = 1f;
    public float CD { get; set; } = 5f;
    public bool IsCD { get; set; }
    public bool IsUnlocked { get; set; } = false;
    public bool IsEquipped { get; set; } = true;
    public float Defence { get; set; }
    public float MoveSpeed { get; set; }

    public bool IsActiveSkill {get; set; } = true;


    public float curDamge;


    // Start is called before the first frame update

    void Awake(){
        player = FindObjectOfType<Player>();
    }
    void Start()
    {
        curDamge = BaseDamage;IsEquipped = true;
        IsCD = false;
        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    public void Active(){
        gameObject.SetActive(true);
    }
    public void DeActive(){
        gameObject.SetActive(false);
    }

    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            enemy.Damage(player.Damage + curDamge);
            Debug.Log(enemy.CurrentHealth);
        }
    }
    public AnimatorStateInfo GetAnimatorStateInfo(){
        AnimatorStateInfo animatorState = animator.GetCurrentAnimatorStateInfo(0);
        return animatorState;
    }
}
