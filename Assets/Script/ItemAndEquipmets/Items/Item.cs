using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item/Item")]
public class Item : ScriptableObject
{
    public new string itemName;
    public Sprite icon;
    public float damage;
    public float health;
    public float moveSpeed;
    public float defence;



}
