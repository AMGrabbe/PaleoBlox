using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddleOne;
    Vector2 distance;
    bool hasStarted = false;
    [SerializeField] float velocityX = 3f;
    [SerializeField] float velocityY = 15f;

    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - paddleOne.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
            StickBallToPaddle();
        LaunchBallOnMouseClick();
    }

    void StickBallToPaddle()
    {
        Vector2 paddleOnePosition = new Vector2(paddleOne.transform.position.x, paddleOne.transform.position.y);
        transform.position = paddleOnePosition + distance;
    }

    void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && !hasStarted)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
            hasStarted = true;
        }
    }
}
