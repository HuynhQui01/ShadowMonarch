using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JobSkill : MonoBehaviour, IPointerClickHandler
{
    SkillManager skillManager;
    public Image image;
    public Sprite empty;
    public Image imageDescription;
    public TMP_Text skillName;
    public TMP_Text skillDescription;
    public SkillUIPanel skillUIPanel;
    // Start is called before the first frame update
    void Start()
    {
        skillManager = FindAnyObjectByType<SkillManager>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            skillUIPanel.OnLeftClick(this);
        }
    }
}
