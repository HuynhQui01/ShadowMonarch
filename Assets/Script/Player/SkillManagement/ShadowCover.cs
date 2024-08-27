using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCover : MonoBehaviour, ISkill
{
    public float BaseDamage { get; set; }
    public float LevelUpDamgePlus { get; set; }
    public float CD { get; set; }
    public bool IsCD { get; set; }
    public bool IsUnlocked { get; set; } = false;
    public bool IsEquipped { get; set; } = false;
    [field: SerializeField]public Sprite sprite { get; set; }
    public float Defence { get; set; } = 10f;
    public float MoveSpeed { get; set; } = 2f;

    public bool IsActiveSkill {get; set; } = true;


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
