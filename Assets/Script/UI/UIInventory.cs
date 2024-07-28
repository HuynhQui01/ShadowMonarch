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
            Time.timeScale = 0;
            isOpen = true;
        }else{
            gameObject.SetActive(false);
            Time.timeScale = 1;
            isOpen = false;
        }
    }

    
}
