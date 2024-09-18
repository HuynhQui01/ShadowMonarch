using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoader : MonoBehaviour
{

    [SerializeField] private GameObject loadingScene;
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private Slider loadingSlider;

    GameObject loadingSceneObject;

    Player player;
    public CinemachineVirtualCamera cinemachineVirtualCamera;


    void Awake(){
        player = FindObjectOfType<Player>();

    }

    public void LoadSceneBtn(string sceneName)
    {
        mainMenu.SetActive(false);
        loadingScene.SetActive(true);
        StartCoroutine(LoadLevelAsync(sceneName));

    }

    IEnumerator LoadLevelAsync(string sceneName)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = loadOperation.progress;
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

