using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoliderDamageable
{
    float MaxHealth { get; set;}
    float CurrentHealth { get; set; }
    void Damage(float damageAmout);
    void Die();
}
