using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public List<Items> Items;
    public List<Equipments> Equipments;

    public void CalculateDropItem(Transform transform)
    {
        foreach (var item in Items)
        {
            float randomValue = Random.Range(0f, 100f);
            if (randomValue <= item.dropRate)
            {
                GameObject itemdrop = Instantiate(item.prefab, transform.position, Quaternion.identity);
                return;
            }
        }

    }

    public void CalculateDropEquipment(Transform transform){
        foreach (var item in Equipments)
        {
            int randomValue = Random.Range(0, item.dropRate);
            Debug.Log(randomValue);
            Debug.Log(item.dropRate);
            if (randomValue <= item.dropRate)
            {
                GameObject itemdrop = Instantiate(item.prefab, transform.position, Quaternion.identity);
                return;
            }
        }
    }
}
