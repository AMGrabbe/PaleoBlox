using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if(currentScene != SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(currentScene+1);
        else 
            CallStartScene();      
    }

    public void CallStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetScore();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
