using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rise : MonoBehaviour, ISkill
{
    public float BaseDamage { get; set; }
    public float LevelUpDamgePlus { get; set; }
    public float CD { get; set; } = 10f;
    public bool IsCD { get; set; } = false;
    public bool IsUnlocked { get; set; } = false;
    public bool IsEquipped { get; set; } = true;
    [field: SerializeField] public Sprite sprite { get; set; }

    public TargetArea targetArea;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public string name = "Shadow Extraction";
    public string description = "CD:\t10s\nCharacter summons soliders from dead enemy ";

    void Start()
    {
        IsEquipped = true;
        animator = GetComponent<Animator>();
        spriteRenderer.enabled = false;
        animator.enabled = false;
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void UseSkill()
    {
        targetArea.enemies.RemoveAll(item => item == null);

        foreach (var enemy in targetArea.enemies)
        {
            if (enemy != null && enemy.isDead)
            {
                GameObject solider = Instantiate(enemy.prefab, enemy.transform.position, Quaternion.identity);
            }
        }
    }

    public void Active()
    {
        spriteRenderer.enabled = true;
        animator.enabled = true;
        gameObject.SetActive(true);
        animator.Play("Rise");
        UseSkill();
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
