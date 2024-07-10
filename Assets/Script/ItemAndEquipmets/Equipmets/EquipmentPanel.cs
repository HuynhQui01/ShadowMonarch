using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    public Player player;
    Equipment[] equipment;

    void Start()
    {
        equipment = GetComponentsInChildren<Equipment>();
    }
    void Update()
    {
        equipment[0].FillImage(player.Chestplate.icon);
        equipment[1].FillImage(player.Helmet.icon);
    }
}
