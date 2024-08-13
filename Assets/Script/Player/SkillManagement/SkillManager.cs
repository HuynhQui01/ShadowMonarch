using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public ThePowerOfTheMonarch thePowerOfTheMonarch;
    public CriticalSlash criticalSlash;
    public Rise rise;
    public ArmorRegenaration armorRegenaration;
    public SkilCDUI skilCDUI;
    public List<ISkill> allSkills = new List<ISkill>();
    public List<ISkill> skillsEquipped = new List<ISkill>();


    void Awake()
    {
    }

    void Start()
    {
        AddSkill();
        SetCDUI();
    }

    void AddSkill()
    {
        allSkills.Add(thePowerOfTheMonarch);
        allSkills.Add(criticalSlash);
        allSkills.Add(rise);
        allSkills.Add(armorRegenaration);
        for (int i = 0; i < allSkills.Count; i++)
        {
            if (allSkills[i].IsEquipped)
            {
                skillsEquipped.Add(allSkills[i]);
                Image image = skilCDUI.sliders[i].GetComponentInChildren<Image>();
                image.sprite = allSkills[i].sprite;
            }
        }
       
    }

    void Update()
    {
        if (skillsEquipped.Count > 0) CDSkill1Update();
        if (skillsEquipped.Count > 1) CDSkill2Update();
        if (skillsEquipped.Count > 2) CDSpecialSkillUpdate();
    }

    public void CDSkill1Update()
    {
        if (skillsEquipped.Count > 0 && skillsEquipped[0].IsCD)
        {
            skilCDUI.sliders[0].value += Time.deltaTime;
            if (skilCDUI.sliders[0].value >= skilCDUI.sliders[0].maxValue)
            {
                skillsEquipped[0].IsCD = false; // Reset cooldown state
                skilCDUI.sliders[0].value = 0; // Reset slider value
            }
        }
    }

    public void CDSkill2Update()
    {
        if (skillsEquipped.Count > 1 && skillsEquipped[1].IsCD)
        {
            skilCDUI.sliders[1].value += Time.deltaTime;
            if (skilCDUI.sliders[1].value >= skilCDUI.sliders[1].maxValue)
            {
                skillsEquipped[1].IsCD = false; 
                skilCDUI.sliders[1].value = 0; 
            }
        }
    }

    public void CDSpecialSkillUpdate()
    {
        if (skillsEquipped.Count > 2 && skillsEquipped[2].IsCD)
        {
            skilCDUI.sliders[2].value += Time.deltaTime;
            if (skilCDUI.sliders[2].value >= skilCDUI.sliders[2].maxValue)
            {
                skillsEquipped[2].IsCD = false; 
                skilCDUI.sliders[2].value = 0; 
            }
        }
    }

    void SetCDUI()
    {
        if (skillsEquipped.Count > 0)
        {
            skilCDUI.sliders[0].maxValue = skillsEquipped[0].CD;
            skilCDUI.sliders[0].value = 0;
        }

        if (skillsEquipped.Count > 1)
        {
            skilCDUI.sliders[1].maxValue = skillsEquipped[1].CD;
            skilCDUI.sliders[1].value = 0;
        }

        if (skillsEquipped.Count > 2)
        {
            skilCDUI.sliders[2].maxValue = skillsEquipped[2].CD;
            skilCDUI.sliders[2].value = 0;
        }
    }
}
