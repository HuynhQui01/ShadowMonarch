using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenceController : MonoBehaviour
{
    public static ScenceController Instance;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    Player player;

    [SerializeField] private SkilCDUI iconPanel;
    [SerializeField] private GameObject loadingScene;

    [SerializeField] private Slider loadingSlider;

    GameObject loadingSceneObject;


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

    void Start()
    {
        loadingScene.SetActive(false);
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        // iconPanel = FindAnyObjectByType<SkilCDUI>();
        if (iconPanel != null)
        {
            if (sceneName == "HomeBaseScene")
            {
                iconPanel.gameObject.SetActive(false);
            }
            else
            {
                iconPanel.gameObject.SetActive(true);
            }
        }
    }

    void CheckScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        player = FindObjectOfType<Player>();
        if (player != null)
        {
            if (sceneName == "HomeBaseScene")
            {
                player.SkillUIPanel.gameObject.SetActive(false);
            }
            else
            {
                if (player.SkillUIPanel.gameObject != null)
                {
                    player.SkillUIPanel.gameObject.SetActive(true);
                }
            }
        }
    }


    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {

        loadingScene.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            float progressValue = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingSlider.value = asyncLoad.progress;
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
                player = FindObjectOfType<Player>();
                // iconPanel = FindAnyObjectByType<SkilCDUI>();
            }

            yield return null;
        }
        loadingScene.SetActive(false);

        player = FindObjectOfType<Player>();
        player.transform.position = new Vector3(0, 0, 0);

        cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        iconPanel = FindAnyObjectByType<SkilCDUI>();

        cinemachineVirtualCamera.Follow = player.transform;


    }
}
