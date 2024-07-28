using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rise : MonoBehaviour
{
    public TargetArea targetArea;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public bool isCD = false;
    public float cd = 10f;

    public Sprite sprite;
    public string name = "Shadow Extraction";
    public string description = "CD:\t10s\nCharacter summons soliders from dead enemy ";

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer.enabled = false;
        animator.enabled = false;
        gameObject.SetActive(false);
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1)
        {
            spriteRenderer.enabled = false;
            animator.enabled = false;
            gameObject.SetActive(false);

        }
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
}
