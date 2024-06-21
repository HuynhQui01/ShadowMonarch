using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxArmor(float maxArmor){
        slider.maxValue = maxArmor;
        slider.value = maxArmor;
    } 

    public void SetArmor(float armor){
        
        slider.value = armor;
        
    }
}
