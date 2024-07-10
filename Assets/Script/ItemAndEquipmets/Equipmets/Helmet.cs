using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Helmet", menuName = "Items/Equipment/Helmet")]
public class Helmet : ScriptableObject
{
    public new string helmetName;
    public float health;
    public Sprite icon;
    public float moveSpeed;
    public float defence;
}
