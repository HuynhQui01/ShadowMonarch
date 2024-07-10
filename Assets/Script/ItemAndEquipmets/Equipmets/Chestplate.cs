using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chestplate", menuName = "Items/Equipment/Chestplate")]
public class Chestplate : ScriptableObject
{
    public float health;
    public string itemName;
    public Sprite icon;
    public float damage;
    public float moveSpeed;
    public float defence;
}
