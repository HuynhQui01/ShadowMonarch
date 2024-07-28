using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string itemName;
    public string description;
    public Sprite icon;

    private GameObject detailsPanel;
    private TextMeshProUGUI detailsText;

    void Start()
    {
        // Tìm kiếm panel và text để hiển thị thông tin chi tiết
        detailsPanel = GameObject.Find("ItemDetails");
        detailsText = detailsPanel.GetComponentInChildren<TextMeshProUGUI>();
        detailsPanel.SetActive(false); // Ẩn panel ban đầu
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowDetails();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideDetails();
    }

    void ShowDetails()
    {
        detailsPanel.SetActive(true);
        detailsText.text = $"Name: {itemName}\nDescription: {description}";
    }

    void HideDetails()
    {
        detailsPanel.SetActive(false);
    }
}
