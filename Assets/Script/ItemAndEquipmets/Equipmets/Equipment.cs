using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private Equipments equipment;
    private InventoryManager inventoryManager;


    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!inventoryManager.CheckNonEquipmentSlotsIsFull())
            {
                inventoryManager.AddEquipment(equipment);
                DeleteEquipment();
            }
        }
    }

    public void DeleteEquipment()
    {
        Destroy(gameObject);
    }
}
