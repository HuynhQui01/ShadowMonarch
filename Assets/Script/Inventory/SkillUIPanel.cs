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

    public void OnLeftClick(PassiveSkills passiveSkill)
    {
        skillDetail.SetActive(true);
    }

    public void OnLeftClick(JobSkill jobSkill)
    {
        skillDetail.SetActive(true);
    }
}
