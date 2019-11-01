using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameSession gameStatus;

    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene+1);
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
