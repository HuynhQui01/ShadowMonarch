using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public Items items;
    private InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="Player"){
            inventoryManager.AddItem(items,this);
            inventoryManager.CheckItemSlotsIsFull();

        }
    } 

    public void DeleteItem(){
        Destroy(gameObject);
    }
}
