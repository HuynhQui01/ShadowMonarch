using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class ItemPanelUI : MonoBehaviour
{
    public Player player;
    ItemUI[] listItem;

    void Start()
    {
        listItem = GetComponentsInChildren<ItemUI>();
    }

    void Update()
    {
        listItem[0].FillImage(player.listItems[0].icon);
        // for (int i = 0; i < 12; i++)
        // {
        //     listItem[i].FillImage(player.listItems[i].icon);
        // }
    }
}
