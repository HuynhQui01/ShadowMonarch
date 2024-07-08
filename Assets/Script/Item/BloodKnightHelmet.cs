using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Blood Knight Helmet", menuName = "Items/Equipment/Blood Knight Helmet")]
public class BloodKnightHelmet : Item
{
    public float health = 50f;
    public string itemName;
    public Sprite icon;
    public float damage;
    public float moveSpeed;
    public float defence;
}
