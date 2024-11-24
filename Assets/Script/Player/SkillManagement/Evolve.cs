using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolve : MonoBehaviour, ISkill
{
    public float BaseDamage { get; set; }
    public float LevelUpDamgePlus { get; set; }
    public float CD { get; set; }
    public bool IsCD { get; set; }
    public bool IsUnlocked { get; set; }
    public bool IsEquipped { get; set; } = true;
    public float Defence { get; set; }
    public float MoveSpeed { get; set; }
    public bool IsActiveSkill { get; set; }
    [field: SerializeField] public Sprite sprite { get; set; }

    Player player;
    bool isUse = false;

    void Awake()
    {

        player = FindObjectOfType<Player>();

    }

    void Update()
    {
        if (isUse)
        {
            player.SoulPoints -= Time.deltaTime * 5f;
            if (player.SoulPoints == 0)
            {
                DeActive();
            }
        }
    }

    public void Active()
    {
        if (player.SoulPoints == 100)
        {
            isUse = true;
            player.Damage += 20f;
            player.MoveSpeed += 1.5f;
            player.Defence += 15f;
            Debug.Log(player.Damage);
        }
    }

    public void DeActive()
    {
        isUse = false;
        player.Damage -= 20f;
        player.MoveSpeed -= 1.5f;
        player.Defence -= 15f;
    }

    public AnimatorStateInfo GetAnimatorStateInfo()
    {
        throw new System.NotImplementedException();
    }
}
