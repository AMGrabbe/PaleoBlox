using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuStatus : MonoBehaviour
{
    GameSession gameSession;
    [SerializeField] TextMeshProUGUI MenuText;

    // Start is called before the first frame update
    void Start()
    {
        MenuText.text = "Welcome to PaleoBlox - Let's get started!";
        if(FindObjectOfType<GameSession>() != null)
            gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameSession != null)
        {
            if(gameSession.CurrentScore > 12000)
                MenuText.text = "You reached:" + gameSession.CurrentScore + " points. \n Not bad try again!";
            else 
                MenuText.text = "You reached:" + gameSession.CurrentScore + " points. \n Not bad try again!";      
        }
    }
}
