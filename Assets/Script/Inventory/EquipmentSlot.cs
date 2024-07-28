using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
{
    #region Equipment Data
    public string equipmentName;
    public Sprite sprite;
    public bool isFull;
    public string equipmentDescription;
    public Sprite emtySprite;
    public Equipments equipments;
    #endregion

    #region equipment Slot
    [SerializeField] private Image image;
    #endregion

    #region 
    public Image equipmentImageDescription;
    public TMP_Text equipmentDescriptionNameText;
    public TMP_Text equipmentDescriptionText;
    #endregion

    public GameObject selectedSlot;
    InventoryManager inventoryManager;
    public bool isSelected;




    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        
    }
    // Start is called before the first frame update
    public void AddEquipment(Equipments equipments)
    {
        this.equipments = equipments;
        this.equipmentName = equipments.name;
        this.sprite = equipments.sprite;
        isFull = true;

        image.sprite = equipments.sprite;
        this.equipmentDescription = equipments.description;
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
            equipmentImageDescription.sprite = sprite;
            equipmentImageDescription.color = new Color(255, 255, 255, 255);
            equipmentDescriptionNameText.text = equipmentName;
            equipmentDescriptionText.text = equipmentDescription;
            if (equipmentImageDescription.sprite == null)
            {
                equipmentImageDescription.sprite = emtySprite;
            }
        }
    }

    void DoubleClick()
    {
        if (equipments)
        {
            inventoryManager.Addnonequipment(equipments);
            inventoryManager.player.SetAttributeWhenUnequip(equipments);
            equipmentDescription =  null;
            equipmentDescriptionNameText.text = null;
            equipmentDescriptionText.text = null;
            equipmentImageDescription.sprite = emtySprite;
            equipments = null;
            isFull = false;
            equipmentName = null;
            image.sprite = emtySprite;
        }
    }
    public void OnRightClick()
    {

    }


}
