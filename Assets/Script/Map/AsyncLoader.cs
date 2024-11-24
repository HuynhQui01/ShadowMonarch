using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoader : MonoBehaviour
{
    GameObject loadingSceneObject;
    Player player;
    public CinemachineVirtualCamera cinemachineVirtualCamera;


    void Awake(){
        player = FindObjectOfType<Player>();

    }

    public void LoadSceneBtn(string sceneName)
    {
        StartCoroutine(LoadLevelAsync(sceneName));

    }

    IEnumerator LoadLevelAsync(string sceneName)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);
        while (!loadOperation.isDone)
        {
            yield return null;
        }

        if(loadOperation.isDone){
            loadingSceneObject = GameObject.Find("LoadingScence");
            loadingSceneObject.SetActive(false);
        }
        
        player = FindObjectOfType<Player>();
        player.transform.position = new Vector3(0, 0, 0);

        cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.Follow = player.transform;
    }
}

