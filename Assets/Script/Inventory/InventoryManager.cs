using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject MessagePanel;
    public TMP_Text messagetext;
    bool menuActived;
    public NonequipmentSlot[] nonEquipmentSlots;
    public ItemSlot[] itemSlot;
    public bool itemSlotIsFull = false;
    public EquipmentSlot[] equipmentSlots;
    public bool equipmentSlotIsFull = false;
    public bool nonequipmentSlotIsFull = false;
    public Sprite sprite;
    public Player player;

    #region ItemPicked Message
    public ItemPickedUI itemPickedUI;
    #endregion


    void Start()
    {
        player = FindObjectOfType<Player>();
        InventoryMenu.SetActive(false);
        MessagePanel.SetActive(false);
    }



    public void OpenAndCloseInventory()
    {
        if (!menuActived)
        {
            InventoryMenu.SetActive(true);
            Time.timeScale = 0;
            menuActived = true;
        }
        else
        {
            InventoryMenu.SetActive(false);
            Time.timeScale = 1;
            menuActived = false;
        }
    }

    private void FillMessageTextEquipment()
    {
        if (nonequipmentSlotIsFull)
        {
            messagetext.text = "Equipment slots are full";
        }

    }

    private void FillMessageTextItem()
    {
        if (itemSlotIsFull)
        {
            messagetext.text = "Item slots are full";
        }
    }

    public void LoadEquipment(Equipments equipments)
    {
        if (equipments)
        {

            switch (equipments.equipmentTypes)
            {
                case Equipments.EquipmentTypes.Helmet:
                    if (equipmentSlots[1].equipments)
                    {
                        equipmentSlots[1].AddEquipment(equipments);
                    }
                    else
                    {
                        if (!nonequipmentSlotIsFull)
                        {
                            Addnonequipment(equipments);

                        }
                    }
                    break;
                case Equipments.EquipmentTypes.Weapon:
                    if (equipmentSlots[0].equipments)
                    {
                        equipmentSlots[0].AddEquipment(equipments);

                    }
                    else
                    {
                        if (!nonequipmentSlotIsFull)
                        {
                            Addnonequipment(equipments);

                        }
                    }
                    break;
                case Equipments.EquipmentTypes.Chestplate:
                    if (equipmentSlots[2].equipments)
                    {
                        equipmentSlots[2].AddEquipment(equipments);

                    }
                    else
                    {
                        if (!nonequipmentSlotIsFull)
                        {

                            Addnonequipment(equipments);

                        }
                    }
                    break;
                case Equipments.EquipmentTypes.Leggings:
                    if (equipmentSlots[3].equipments)
                    {
                        equipmentSlots[3].AddEquipment(equipments);

                    }
                    else
                    {
                        if (!nonequipmentSlotIsFull)
                        {
                            Addnonequipment(equipments);

                        }
                    }
                    break;
                case Equipments.EquipmentTypes.Boots:
                    if (equipmentSlots[4].equipments)
                    {
                        equipmentSlots[4].AddEquipment(equipments);

                    }
                    else
                    {
                        if (!nonequipmentSlotIsFull)
                        {
                            Addnonequipment(equipments);

                        }
                    }
                    break;
                case Equipments.EquipmentTypes.RightEaring:
                    if (equipmentSlots[5].equipments)
                    {
                        equipmentSlots[5].AddEquipment(equipments);

                    }
                    else
                    {
                        if (!nonequipmentSlotIsFull)
                        {
                            Addnonequipment(equipments);

                        }
                    }
                    break;
                case Equipments.EquipmentTypes.LeftEaring:
                    if (equipmentSlots[6].equipments)
                    {
                        equipmentSlots[6].AddEquipment(equipments);

                    }
                    else
                    {
                        if (!nonequipmentSlotIsFull)
                        {
                            Addnonequipment(equipments);

                        }
                    }
                    break;
                case Equipments.EquipmentTypes.Necklace:
                    if (equipmentSlots[7].equipments)
                    {
                        equipmentSlots[7].AddEquipment(equipments);

                    }
                    else
                    {
                        if (!nonequipmentSlotIsFull)
                        {
                            Addnonequipment(equipments);

                        }
                    }
                    break;
                case Equipments.EquipmentTypes.LeftHandRing:
                    if (equipmentSlots[8].equipments)
                    {
                        equipmentSlots[8].AddEquipment(equipments);

                    }
                    else
                    {
                        if (!nonequipmentSlotIsFull)
                        {
                            Addnonequipment(equipments);

                        }
                    }
                    break;
                case Equipments.EquipmentTypes.RightHandRing:
                    if (equipmentSlots[9].equipments)
                    {
                        equipmentSlots[9].AddEquipment(equipments);

                    }
                    else
                    {
                        if (!nonequipmentSlotIsFull)
                        {
                            Addnonequipment(equipments);

                        }
                    }
                    break;
            }
        }

    }

    public void AddEquipment(Equipments equipments)
    {
        switch (equipments.equipmentTypes)
        {
            case Equipments.EquipmentTypes.Helmet:
                if (!equipmentSlots[1].equipments)
                {
                    equipmentSlots[1].AddEquipment(equipments);
                    player.SetAttributeWhenEquip(equipments);
                    itemPickedUI.InstantiateUIPrefab(equipments);
                }
                else
                {
                    if (!nonequipmentSlotIsFull)
                    {
                        Addnonequipment(equipments);
                    }
                    else
                    {
                        StartCoroutine(ShowMessage());
                    }
                }
                break;
            case Equipments.EquipmentTypes.Weapon:
                if (!equipmentSlots[0].equipments)
                {
                    equipmentSlots[0].AddEquipment(equipments);
                    player.SetAttributeWhenEquip(equipments);
                    itemPickedUI.InstantiateUIPrefab(equipments);

                }
                else
                {
                    if (!nonequipmentSlotIsFull)
                    {
                        Addnonequipment(equipments);


                    }
                    else
                    {
                        StartCoroutine(ShowMessage());

                    }
                }
                break;
            case Equipments.EquipmentTypes.Chestplate:
                if (!equipmentSlots[2].equipments)
                {
                    equipmentSlots[2].AddEquipment(equipments);
                    player.SetAttributeWhenEquip(equipments);
                    itemPickedUI.InstantiateUIPrefab(equipments);

                }
                else
                {
                    if (!nonequipmentSlotIsFull)
                    {

                        Addnonequipment(equipments);


                    }
                    else
                    {
                        StartCoroutine(ShowMessage());

                    }
                }
                break;
            case Equipments.EquipmentTypes.Leggings:
                if (!equipmentSlots[3].equipments)
                {
                    equipmentSlots[3].AddEquipment(equipments);
                    player.SetAttributeWhenEquip(equipments);
                    itemPickedUI.InstantiateUIPrefab(equipments);

                }
                else
                {
                    if (!nonequipmentSlotIsFull)
                    {
                        Addnonequipment(equipments);


                    }
                    else
                    {
                        StartCoroutine(ShowMessage());

                    }
                }
                break;
            case Equipments.EquipmentTypes.Boots:
                if (!equipmentSlots[4].equipments)
                {
                    equipmentSlots[4].AddEquipment(equipments);
                    player.SetAttributeWhenEquip(equipments);
                    itemPickedUI.InstantiateUIPrefab(equipments);

                }
                else
                {
                    if (!nonequipmentSlotIsFull)
                    {
                        Addnonequipment(equipments);


                    }
                    else
                    {
                        StartCoroutine(ShowMessage());

                    }
                }
                break;
            case Equipments.EquipmentTypes.RightEaring:
                if (!equipmentSlots[5].equipments)
                {
                    equipmentSlots[5].AddEquipment(equipments);
                    player.SetAttributeWhenEquip(equipments);
                    itemPickedUI.InstantiateUIPrefab(equipments);

                }
                else
                {
                    if (!nonequipmentSlotIsFull)
                    {
                        Addnonequipment(equipments);


                    }
                    else
                    {
                        StartCoroutine(ShowMessage());

                    }
                }
                break;
            case Equipments.EquipmentTypes.LeftEaring:
                if (!equipmentSlots[6].equipments)
                {
                    equipmentSlots[6].AddEquipment(equipments);
                    player.SetAttributeWhenEquip(equipments);
                    itemPickedUI.InstantiateUIPrefab(equipments);

                }
                else
                {
                    if (!nonequipmentSlotIsFull)
                    {
                        Addnonequipment(equipments);


                    }
                    else
                    {
                        StartCoroutine(ShowMessage());

                    }
                }
                break;
            case Equipments.EquipmentTypes.Necklace:
                if (!equipmentSlots[7].equipments)
                {
                    equipmentSlots[7].AddEquipment(equipments);
                    player.SetAttributeWhenEquip(equipments);
                    itemPickedUI.InstantiateUIPrefab(equipments);

                }
                else
                {
                    if (!nonequipmentSlotIsFull)
                    {
                        Addnonequipment(equipments);


                    }
                    else
                    {
                        StartCoroutine(ShowMessage());

                    }
                }
                break;
            case Equipments.EquipmentTypes.LeftHandRing:
                if (!equipmentSlots[8].equipments)
                {
                    equipmentSlots[8].AddEquipment(equipments);
                    player.SetAttributeWhenEquip(equipments);
                    itemPickedUI.InstantiateUIPrefab(equipments);

                }
                else
                {
                    if (!nonequipmentSlotIsFull)
                    {
                        Addnonequipment(equipments);


                    }
                    else
                    {
                        StartCoroutine(ShowMessage());

                    }
                }
                break;
            case Equipments.EquipmentTypes.RightHandRing:
                if (!equipmentSlots[9].equipments)
                {
                    equipmentSlots[9].AddEquipment(equipments);
                    player.SetAttributeWhenEquip(equipments);
                    itemPickedUI.InstantiateUIPrefab(equipments);

                }
                else
                {
                    if (!nonequipmentSlotIsFull)
                    {
                        Addnonequipment(equipments);


                    }
                    else
                    {
                        StartCoroutine(ShowMessage());
                    }
                }
                break;
        }
    }

    public void Addnonequipment(Equipments equipment)
    {

        for (int i = 0; i < nonEquipmentSlots.Length; i++)
        {
            if (nonEquipmentSlots[i].isFull == false)
            {
                nonEquipmentSlots[i].AddNonequipment(equipment);
                itemPickedUI.InstantiateUIPrefab(equipment);
                return;
            }
        }

    }

    public bool CheckNonEquipmentSlotsIsFull()
    {
        int count = 0;
        for (int i = 0; i < nonEquipmentSlots.Length; i++)
        {
            if (nonEquipmentSlots[i].isFull == true)
            {
                count++;
            }

        }
        if (count == nonEquipmentSlots.Length)
        {
            nonequipmentSlotIsFull = true;
            FillMessageTextEquipment();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheckItemSlotsIsFull()
    {
        int count = 0;
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == true)
            {
                count++;
            }
            if (count == itemSlot.Length)
            {
                itemSlotIsFull = true;
                FillMessageTextItem();
            }

        }
    }

    IEnumerator ShowMessage()
    {
        MessagePanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        MessagePanel.SetActive(false);
    }

    public void LoadItems(Items item)
    {
        if (item)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i].isFull == false)
                {
                    itemSlot[i].AddItem(item);
                    return;
                }
            }
        }
    }
    public void AddItem(Items item, Item curItem)
    {
        if (!itemSlotIsFull)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i].isFull == false)
                {
                    itemSlot[i].AddItem(item);
                    curItem.DeleteItem();
                    itemPickedUI.InstantiateUIPrefab(item);
                    return;
                }
            }
        }
        else
        {
            StartCoroutine(ShowMessage());
        }

    }

    public void DeselectedAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedSlot.SetActive(false);
            itemSlot[i].isSelected = false;
        }
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].selectedSlot.SetActive(false);
            equipmentSlots[i].isSelected = false;
        }
        for (int i = 0; i < nonEquipmentSlots.Length; i++)
        {
            nonEquipmentSlots[i].selectedSlot.SetActive(false);
            nonEquipmentSlots[i].isSelected = false;
        }
    }
}
