using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEquipment : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] RandomEquipment randomEquipment;
    Equipments equipments;
    [SerializeField] GameObject panel;

    bool isDetectedPlayer = false;
    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        equipments = randomEquipment.GetRandomEquipment();
        Debug.Log(equipments);
        spriteRenderer.sprite = equipments.sprite;
        panel.gameObject.SetActive(false);

    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            isDetectedPlayer = true;
            panel.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            isDetectedPlayer = false;
            panel.gameObject.SetActive(false);
        }
    }

    void Update(){
        if (isDetectedPlayer && Input.GetKeyDown(KeyCode.F))
        {
            inventoryManager.AddEquipment(equipments);
            Destroy(gameObject);
        }
    }
}
