using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class RoomCheck : MonoBehaviour
{
    [SerializeField] private GameObject virtualCam;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            virtualCam.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
                        virtualCam.SetActive(false);


        }
    }
}
