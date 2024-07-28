using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Items : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite sprite;
    public float health;
    public float armor;
    public float moveSpeed;
    public float damage;
    public float defence;
    public GameObject prefab;

    public ItemType itemType = new ItemType();


    public enum ItemType{
        SkillStone,
        Attribute,
        Material
    }
}
