using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddleOne;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] ballSound;


    Vector2 distance;
    bool hasStarted = false;
    AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - paddleOne.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            StickBallToPaddle();

            LaunchBallOnMouseClick();
        }
    }

    private void StickBallToPaddle()
    {
        Vector2 paddleOnePosition = new Vector2(paddleOne.transform.position.x, paddleOne.transform.position.y);
        transform.position = paddleOnePosition + distance;
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip clip = ballSound[UnityEngine.Random.Range(0, ballSound.Length)];
        if (hasStarted)
        {
            myAudioSource.PlayOneShot(clip);
        }

    }
}
