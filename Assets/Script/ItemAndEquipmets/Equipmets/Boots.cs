using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boots", menuName = "Items/Equipment/Boots")]

public class Boots : ScriptableObject
{
    public new string bootsName;
    public float health;
    public Sprite icon;
    public float moveSpeed;
    public float defence;
}
