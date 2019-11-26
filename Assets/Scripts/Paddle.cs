using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float widthInUnityUnits = 16f;
    [SerializeField] float ScreenBoundaryMin = 1f;
    [SerializeField] float ScreenBoundaryMax = 15f;
    
    private GameSession gameSession;
    private Ball ball;
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPosition(), ScreenBoundaryMin, ScreenBoundaryMax);
        transform.position = paddlePosition;
    }

    private float GetXPosition()
    {
        if(gameSession.IsAutoplayEnabled() == true)
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * widthInUnityUnits;
        }
    }
}
