using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickedUI : MonoBehaviour
{
    public GameObject uiPrefab;
    public Transform uiParent;
    // Start is called before the first frame update
    void Start()
    {
        uiParent = this.transform;
        gameObject.SetActive(true);
    }

    public void InstantiateUIPrefab(Equipments equipment)
    {
        GameObject newUIElement = Instantiate(uiPrefab, uiParent);
        ItemPickedPanel itemPickedPanel = newUIElement.GetComponent<ItemPickedPanel>();

        itemPickedPanel.itemPickedImage.sprite = equipment.sprite;
        itemPickedPanel.itemPickedText.text = equipment.name;
        gameObject.SetActive(true);
        newUIElement.gameObject.SetActive(true);
        itemPickedPanel.gameObject.SetActive(true);

        StartCoroutine(DisplayItem(newUIElement));

    }

    public void InstantiateUIPrefab(Items item)
    {
        GameObject newUIElement = Instantiate(uiPrefab, uiParent);
        ItemPickedPanel itemPickedPanel = newUIElement.GetComponent<ItemPickedPanel>();

        itemPickedPanel.itemPickedImage.sprite = item.sprite;
        itemPickedPanel.itemPickedText.text = item.name;
        gameObject.SetActive(true);

        newUIElement.gameObject.SetActive(true);
        itemPickedPanel.gameObject.SetActive(true);
        StartCoroutine(DisplayItem(newUIElement));

    }

    IEnumerator DisplayItem(GameObject newUIElement)
    {
        yield return new WaitForSeconds(2);
        Destroy(newUIElement);
    }
}
