using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoliderIdleSOBase : ScriptableObject
{
    protected Solider solider;
    protected Transform transform;
    protected GameObject gameObject;
    protected Transform playerTransform;

    public virtual void Initialize(GameObject gameObject, Solider solider){
        this.gameObject =  gameObject;
        transform = gameObject.transform;
        this.solider = solider;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void DoEnterLogic(){
        
    }
    public virtual void DoExitLogic(){ResetValues();}
    public virtual void DoFrameUpdateLogic(){
        
    }
    public virtual void DoPhysicUpdateLogic(){}
    public virtual void ResetValues(){}
}
