using System;
using System.Collections.Generic;
using UnityEditor.PackageManager;

[Serializable]
public class GameData
{
    public float[] position;
    public int coin;
    public InventoryManager inventoryManager;
    public float experience;
    public int level;
    public float MaxExperience;
    public List<Equipments> equipmentsList;
    public List<Items> itemsList;

    public GameData(Player player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        this.coin = player.coin;
        inventoryManager = player.inventoryManager;
        experience = player.Experience;
        level = player.Level;
        MaxExperience = player.MaxExperience;
        equipmentsList = player.equipmentsList;
        itemsList = player.itemsList;

    }
}
