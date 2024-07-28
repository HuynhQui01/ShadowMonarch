using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NonequipmentSlot : MonoBehaviour, IPointerClickHandler
{
    #region nonequipment Data
    public string nonequipmentName;
    public Sprite sprite;
    public bool isFull;
    public string nonequipmentDescription;
    public Sprite emtySprite;
    public Equipments nonequipment;
    #endregion

    #region nonequipment Slot
    [SerializeField] private Image image;
    #endregion

    #region 
    public Image nonequipmentImageDescription;
    public TMP_Text nonequipmentDescriptionNameText;
    public TMP_Text nonequipmentDescriptionText;
    #endregion

    public GameObject selectedSlot;
    InventoryManager inventoryManager;
    public bool isSelected;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    // Start is called before the first frame update
    public void AddNonequipment(Equipments equipments)
    {
        nonequipment = equipments;
        this.nonequipmentName = equipments.name;
        this.sprite = equipments.sprite;
        isFull = true;

        image.sprite = sprite;
        this.nonequipmentDescription = equipments.description;
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
            nonequipmentImageDescription.sprite = sprite;
            nonequipmentImageDescription.color = new Color(255, 255, 255, 255);
            nonequipmentDescriptionNameText.text = nonequipmentName;
            nonequipmentDescriptionText.text = nonequipmentDescription;
            if (nonequipmentImageDescription.sprite == null)
            {
                nonequipmentImageDescription.sprite = emtySprite;
            }
        }

    }
    void DoubleClick()
    {
        if (nonequipment)
        {
            inventoryManager.AddEquipment(nonequipment);
            nonequipment = null;
            nonequipmentDescription = null;
            nonequipmentImageDescription.sprite = emtySprite;
            nonequipmentDescriptionNameText.text = null;
            nonequipmentDescriptionText.text = null;
            nonequipmentName = null;

            isFull = false;
            image.sprite = emtySprite;
        }
    }
    public void OnRightClick()
    {

    }
}
