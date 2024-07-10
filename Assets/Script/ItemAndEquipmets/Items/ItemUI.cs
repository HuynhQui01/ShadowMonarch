using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image _image;
    void Awake(){
        _image = GetComponent<Image>();
    }
    public void FillImage(Sprite sprite){
        _image.sprite = sprite;
    }
}
