using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    bool isOpen = true;
    public void ShowAndHide()
    {
        if (!isOpen)
        {
            gameObject.SetActive(true);
            isOpen = true;
        }else{
            gameObject.SetActive(false);
            isOpen = false;
        }
    }

    
}
