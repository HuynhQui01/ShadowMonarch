using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PassiveSkills : MonoBehaviour, IPointerClickHandler
{
    public SkillManager skillManager;
    public Image image;
    public Sprite empty;
    public Image imageDescription;
    public TMP_Text skillName;
    public TMP_Text skillDescription;
    public SkillUIPanel skillUIPanel;
    // Start is called before the first frame update
    void Awake()
    {
        skillManager = FindAnyObjectByType<SkillManager>();
        image = GetComponent<Image>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left && eventData.clickCount == 2){
            skillUIPanel.OnDoubleClick(this);
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            skillUIPanel.OnLeftClick(this);
        }
    }
}
