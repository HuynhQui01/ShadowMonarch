using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
   [SerializeField] private string sceneToLoad;
   [SerializeField] private string SceneTransitionName;
   


   void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.GetComponent<PlayerController>()){
            SceneManager.LoadScene(sceneToLoad);
            PlayerController.Instance.transform.position = new Vector3(0, 0, 0);
            
            SceneManagement.Instance.SetTransitionName(SceneTransitionName);
            CameraController1.Instance.SetPlayerCameraFollow();
        }
   }
}
