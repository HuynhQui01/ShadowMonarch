using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public PortalName portalName;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            ScenceController.Instance.LoadScene(portalName.portalName);
        }
    }
}
