using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill 
{
    float BaseDamage { get; set; }
    float LevelUpDamgePlus { get; set; }
    float CD { get; set; } 
    bool IsCD { get; set; }
    bool IsUnlocked { get; set; }
    bool IsEquipped { get; set; }

    void Active();
    void DeActive();
    public Sprite sprite { get; set; }
     AnimatorStateInfo GetAnimatorStateInfo();
}
