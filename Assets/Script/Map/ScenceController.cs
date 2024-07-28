using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceController : MonoBehaviour
{
    public static ScenceController Instance;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    Player player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }

        player = FindObjectOfType<Player>();
    }

    // public async void LoadScene(string sceneName)
    // {
    //     await SceneManager.LoadSceneAsync(sceneName);
    //     player.transform.position = new Vector3(0, 0, 0);
    //     cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    //     cinemachineVirtualCamera.Follow = player.transform;

    // }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        player = FindObjectOfType<Player>();
        player.transform.position = new Vector3(0, 0, 0);

        cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.Follow = player.transform;
    }
}
