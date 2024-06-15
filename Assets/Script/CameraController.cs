using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineStateDrivenCamera cinemachineRoom1;
    [SerializeField] private CinemachineStateDrivenCamera cinemachineRoom2;
    
    // [SerializeField] private CinemachineStateDrivenCamera cinemachineRoom3;

    void Start(){
        cinemachineRoom1.enabled = true;
        cinemachineRoom2.enabled = false;
        // cinemachineRoom3.enabled = false;
    }


    
}
