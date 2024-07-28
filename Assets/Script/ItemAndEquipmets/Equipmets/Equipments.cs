using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Equipment")]
public class Equipments : ScriptableObject
{

    public string equipmentName;
    public Sprite sprite;
    public float health;
    public float damage;
    public float movementSpeed;
    public float defence;
    [TextArea]public string description;

    public EquipmentTypes equipmentTypes = new EquipmentTypes();

    public enum EquipmentTypes{
        Weapon,
        Helmet,
        Chestplate,
        Leggings,
        Boots,
        RightEaring,
        LeftEaring,
        Necklace,
        LeftHandRing,
        RightHandRing
    }
}
