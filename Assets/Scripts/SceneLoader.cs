using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    #region Properties

    private int sceneToLoad;

    //Singleton
    public static SceneLoader Instance
    {
        get; private set;
    }

    #endregion

    #region Unity Functions

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    #endregion

    #region Class Functions

    public void LoadScene(int sceneToLoad)
    {
        this.sceneToLoad = sceneToLoad;

        StartCoroutine(LoadScene());
    }

    public void LoadNextScene()
    {
        switch (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings-1)
        {
            case true:
                sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
                StartCoroutine(LoadScene());
                break;

            case false:
                sceneToLoad = 0;
                StartCoroutine(LoadScene());
                break;
        }
    }

    public void ReloadScene()
    {
        sceneToLoad = SceneManager.GetActiveScene().buildIndex;

        StartCoroutine(LoadScene());
    }

    #endregion

    #region Coroutines

    private IEnumerator LoadScene()
    {
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
    }

    #endregion
}
