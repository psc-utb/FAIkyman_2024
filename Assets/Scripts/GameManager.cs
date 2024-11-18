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
}
