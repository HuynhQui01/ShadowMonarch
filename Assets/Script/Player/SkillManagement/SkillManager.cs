using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public ThePowerOfTheMonarch thePowerOfTheMonarch;
    public CriticalSlash criticalSlash;
    public Rise rise;
    public SkilCDUI skilCDUI;
    

    void Awake(){
        thePowerOfTheMonarch = FindObjectOfType<ThePowerOfTheMonarch>();
        criticalSlash = FindAnyObjectByType<CriticalSlash>();
        rise = FindAnyObjectByType<Rise>();
    }

    void Start(){
        SetCDUI();
    }

    void Update(){
        CDSkill1Update();
        CDSkill2Update();
        CDSpecialSkillUpdate();
    }

    public void CDSkill1Update(){
        if (criticalSlash.isCD) 
        {
            skilCDUI.sliders[0].value += Time.deltaTime;
            if (skilCDUI.sliders[0].value >= skilCDUI.sliders[0].maxValue)
            {
                criticalSlash.isCD = false; // Reset cooldown state
                skilCDUI.sliders[0].value = 0; // Reset slider value
            }
        }
    }
    public void CDSkill2Update(){
        if (thePowerOfTheMonarch.isCD) 
        {
            skilCDUI.sliders[1].value += Time.deltaTime;
            if (skilCDUI.sliders[1].value >= skilCDUI.sliders[1].maxValue)
            {
                thePowerOfTheMonarch.isCD = false; // Reset cooldown state
                skilCDUI.sliders[1].value = 0; // Reset slider value
            }
        }
    }
    public void CDSpecialSkillUpdate(){
        if (rise.isCD) 
        {
            skilCDUI.sliders[2].value += Time.deltaTime;
            if (skilCDUI.sliders[2].value >= skilCDUI.sliders[2].maxValue)
            {
                rise.isCD = false; // Reset cooldown state
                skilCDUI.sliders[2].value = 0; // Reset slider value
            }
        }
    }

    void SetCDUI(){
        skilCDUI.sliders[0].maxValue = criticalSlash.cd;
        skilCDUI.sliders[0].value = 0;

        skilCDUI.sliders[1].maxValue = thePowerOfTheMonarch.cd;
        skilCDUI.sliders[1].value = 0;

        skilCDUI.sliders[2].maxValue = rise.cd;
        skilCDUI.sliders[2].value = 0;
    }
}
