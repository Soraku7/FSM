using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public static void ReloadScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(sceneIndex);
    }

    public static void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

    #else
        Application.Quit();
    #endif
    }

    public static void LoadNextScence()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (sceneIndex >= SceneManager.sceneCount)
        {
            ReloadScene();
            return;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}
