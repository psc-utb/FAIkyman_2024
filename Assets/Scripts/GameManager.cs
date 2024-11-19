using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("BossScene");
    }

    public void DeathScene(float delay)
    {
        StartCoroutine(LoadSceneAfterSecond("Death", delay));
    }

    private IEnumerator LoadSceneAfterSecond(string sceneName, float delay)
    {
        if (string.IsNullOrEmpty(sceneName) == false)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(sceneName);
        }
    }


    [SerializeField]
    bool mainMenuCanBeDisplayed = false;
    [SerializeField]
    private string mainMenuSceneName;

    AudioListener audioListenerInScene;

    // set things up here
    void Awake()
    {
        audioListenerInScene = FindObjectOfType<AudioListener>();
    }

    // game loop
    void Update()
    {
        if (mainMenuCanBeDisplayed == true && Input.GetButtonDown("Menu"))
        {
            if (Time.timeScale > 0f)
            {
                audioListenerInScene.enabled = false;
                SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Additive);
                Time.timeScale = 0f;
            }
            else
            {
                AsyncOperation asyncOpUnloadScene = SceneManager.UnloadSceneAsync(mainMenuSceneName);
                asyncOpUnloadScene.completed += UnloadScene_completed;
                Time.timeScale = 1f;
            }
        }
    }

    private void UnloadScene_completed(AsyncOperation obj)
    {
        if (audioListenerInScene != null)
            audioListenerInScene.enabled = true;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
        if (audioListenerInScene != null)
            audioListenerInScene.enabled = true;
    }
}
