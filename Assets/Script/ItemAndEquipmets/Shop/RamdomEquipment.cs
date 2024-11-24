using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Random Equipment", menuName = "Random Equipment")]

public class RandomEquipment : MonoBehaviour
{
    [SerializeField] List<Equipments> equipmentList;

     public Equipments GetRandomEquipment()
    {
        if (equipmentList == null || equipmentList.Count == 0)
        {
            Debug.LogWarning("Equipment list is empty or null.");
            return null; 
        }
        Debug.LogWarning(equipmentList.Count);

        int randomIndex = Random.Range(0, equipmentList.Count); 
        return equipmentList[randomIndex];
    }
}
