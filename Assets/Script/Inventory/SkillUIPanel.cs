using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUIPanel : MonoBehaviour
{
    public PassiveSkills[] passiveSkills;
    public ActiveSkills[] activeSkills;
    public JobSkill[] jobSkills;
    public SkillManager skillManager;
    public GameObject skillDetail;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        skillDetail.SetActive(false);
        gameObject.SetActive(false);
    }

    void Initialize()
    {
        activeSkills[0].image.sprite = skillManager.criticalSlash.sprite;
        activeSkills[1].image.sprite = skillManager.thePowerOfTheMonarch.sprite;
        activeSkills[2].image.sprite = skillManager.rise.sprite;
        passiveSkills[0].image.sprite = skillManager.armorRegenaration.sprite;
    }

    public void OnLeftClick(ActiveSkills activeSkill)
    {
        skillDetail.SetActive(true);
        if (activeSkill.Equals(activeSkills[0]))
        {
            activeSkill.imageDescription.sprite = skillManager.criticalSlash.sprite;
            activeSkill.skillName.text = skillManager.criticalSlash.name;
            activeSkill.skillDescription.text = skillManager.criticalSlash.description;
        }
        else if (activeSkill.Equals(activeSkills[1]))
        {
            activeSkill.imageDescription.sprite = skillManager.thePowerOfTheMonarch.sprite;
            activeSkill.skillName.text = skillManager.thePowerOfTheMonarch.name;
            activeSkill.skillDescription.text = skillManager.thePowerOfTheMonarch.description;
        }
        else if (activeSkill.Equals(activeSkills[2]))
        {
            activeSkill.imageDescription.sprite = skillManager.rise.sprite;
            activeSkill.skillName.text = skillManager.rise.name;
            activeSkill.skillDescription.text = skillManager.rise.description;

        }

    }

    public void OnDoubleClick(ActiveSkills activeSkill)
    {
        skillDetail.SetActive(true);
        if (activeSkill.Equals(activeSkills[0]))
        {
            if (activeSkill.skillManager.criticalSlash.IsUnlocked)
            {
                if (activeSkill.skillManager.criticalSlash.IsEquipped)
                {
                    activeSkill.skillManager.criticalSlash.IsEquipped = false;
                }
                else
                {
                    activeSkill.skillManager.criticalSlash.IsEquipped = true;
                }
                Debug.Log(activeSkill.skillManager.criticalSlash.IsEquipped);
            }
        }
        if (activeSkill.Equals(activeSkills[1]))
        {
            if (activeSkill.skillManager.thePowerOfTheMonarch.IsUnlocked)
            {
                if (activeSkill.skillManager.thePowerOfTheMonarch.IsEquipped)
                {
                    activeSkill.skillManager.thePowerOfTheMonarch.IsEquipped = false;
                }
                else
                {
                    activeSkill.skillManager.thePowerOfTheMonarch.IsEquipped = true;
                }
            }
        }
        if (activeSkill.Equals(activeSkills[1]))
        {
            if (activeSkill.skillManager.rise.IsUnlocked)
            {
                if (activeSkill.skillManager.rise.IsEquipped)
                {
                    activeSkill.skillManager.rise.IsEquipped = false;
                }
                else
                {
                    activeSkill.skillManager.rise.IsEquipped = true;
                }
            }
        }
    }

    public void OnLeftClick(PassiveSkills passiveSkill)
    {
        skillDetail.SetActive(true);
        if (passiveSkill.Equals(passiveSkills[0]))
        {
            passiveSkill.imageDescription.sprite = skillManager.armorRegenaration.sprite;
            passiveSkill.skillName.text = skillManager.armorRegenaration.name;
            passiveSkill.skillDescription.text = skillManager.armorRegenaration.description;
        }
    }
    public void OnDoubleClick(PassiveSkills passiveSkill){
        skillDetail.SetActive(true);

        if (passiveSkill.Equals(passiveSkills[0]))
        {
            if (passiveSkill.skillManager.armorRegenaration.IsUnlocked)
            {
                if (passiveSkill.skillManager.armorRegenaration.IsEquipped)
                {
                    passiveSkill.skillManager.armorRegenaration.IsEquipped = false;
                }
                else
                {
                    passiveSkill.skillManager.armorRegenaration.IsEquipped = true;
                }
                Debug.Log(passiveSkill.skillManager.armorRegenaration.IsEquipped);
            }
        }
    }

    public void OnLeftClick(JobSkill jobSkill)
    {
        skillDetail.SetActive(true);
    }
}
