using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalInstanceLoad : MonoBehaviour
{
    public PortalName portalName;
    public AsyncLoader asyncLoader;
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            asyncLoader.LoadSceneBtn(portalName.portalName);
        }
    }
}
