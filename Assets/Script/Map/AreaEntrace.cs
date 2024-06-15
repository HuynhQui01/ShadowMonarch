using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrace : MonoBehaviour
{
    [SerializeField] private string transitionName;
    [SerializeField] private GameObject spawnPoint;
    private void Start(){
        if(transitionName == SceneManagement.Instance.SceneTransitionName){
            print("aaaaa");
        }
    }
}
