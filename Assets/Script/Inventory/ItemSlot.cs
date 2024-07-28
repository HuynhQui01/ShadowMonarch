using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    #region Item Data
    public string itemName;
    public Sprite sprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emtySprite;
    public Items item;
    #endregion

    #region Item Slot
    [SerializeField] private Image image;
    #endregion

    #region 
    public Image itemImageDescription;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;
    #endregion

    public GameObject selectedSlot;
    InventoryManager inventoryManager;
    public bool isSelected;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

    }
    // Start is called before the first frame update
    public void AddItem(Items item)
    {
        this.item = item;
        this.itemName = item.itemName;
        this.sprite = item.sprite;
        isFull = true;

        image.sprite = item.sprite;
        this.itemDescription = item.itemDescription;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick(eventData);
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }



    public void OnLeftClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && eventData.clickCount == 2)
        {
            DoubleClick();
        }
        else
        {
            inventoryManager.DeselectedAllSlots();
            selectedSlot.SetActive(true);
            isSelected = true;
            itemImageDescription.sprite = sprite;
            itemImageDescription.color = new Color(255, 255, 255, 255);
            itemDescriptionNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
            if (itemImageDescription.sprite == null)
            {
                itemImageDescription.sprite = emtySprite;
            }
        }
    }

    void DoubleClick(){
        
    }
    public void OnRightClick()
    {
        GameObject itemDropped = Instantiate(item.prefab, inventoryManager.player.transform.position - new Vector3(1, 0, 0), Quaternion.identity);
        this.item = null;
        this.itemName = null;
        this.sprite = null;
        isFull = false;

        image.sprite = emtySprite;
        this.itemDescription = null;
    }




}
