using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderMoveSOBase : ScriptableObject
{

    protected Solider Solider;
    protected Transform transform;
    protected GameObject gameObject;
    protected Transform playerTransform;

    public virtual void Initialize(GameObject gameObject, Solider Solider)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.Solider = Solider;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public virtual void DoEnterLogic()
    {

    }
    public virtual void DoExitLogic() { ResetValues(); }
    public virtual void DoFrameUpdateLogic(){    }
    public virtual void DoPhysicUpdateLogic() { }
    public virtual void ResetValues() { }
}
