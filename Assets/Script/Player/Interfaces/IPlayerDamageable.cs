using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerDamageable 
{
    float MaxHealth { get; set;}
    float CurrentHealth { get; set; }
    float MaxArmor { get; set; }
    float CurrentArmor { get; set; }

    void TakeDamage(float damageAmout);
    void Die();
}
