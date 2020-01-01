using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuStatus : MonoBehaviour
{
    GameSession gameSession;
    [SerializeField] TextMeshProUGUI MenuText;

    void Start()
    {
        MenuText.text = "Welcome to PaleoBlox - Let's get started!";
        if(FindObjectOfType<GameSession>() != null)
            gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        if(gameSession != null)
        {
            int score = gameSession.CurrentScore;
            if (gameSession.CurrentScore < 100)
                MenuText.text = "You reached:" + score + " points. \n You can do it better. Try again!";
            else if (gameSession.CurrentScore >= 100)
                MenuText.text = "You reached:" + score + " points. \n Not bad try again!";      
        }
    }
}
