using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Legging", menuName = "Items/Equipment/Legging")]

public class Legging : ScriptableObject
{
    public new string LeggingName;
    public float health;
    public Sprite icon;
    public float moveSpeed;
    public float defence;
}
