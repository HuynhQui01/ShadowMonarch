using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorRegenaration :MonoBehaviour, ISkill
{
    public float BaseDamage { get; set; } = 2f;
    public float LevelUpDamgePlus { get; set; }
    public float CD { get; set; }
    public bool IsCD { get; set; }
    public bool IsUnlocked { get; set; } = false;
    public bool IsEquipped { get; set; } = true;
    [field:SerializeField] public Sprite sprite { get; set; }
    Player player;
    public string description = "Increase armor regeneration rate by 2 per second";

    void Start(){
        player = FindObjectOfType<Player>();
    }

    void Update(){
        if(IsEquipped){
            player.regenArmorRate += BaseDamage;
        }
    }

    public void Active()
    {
        throw new System.NotImplementedException();
    }

    public void DeActive()
    {
        throw new System.NotImplementedException();
    }

    public AnimatorStateInfo GetAnimatorStateInfo()
    {
        throw new System.NotImplementedException();
    }
}
