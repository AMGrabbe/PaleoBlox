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
    Rigidbody2D rigidbody;
    Vector2 actualPosition;


    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - paddleOne.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();
        actualPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!hasStarted)
        {
            StickBallToPaddle();

            LaunchBallOnMouseClick();
           
        }
        else
        {
            Vector2 direction = new Vector2(transform.position.x, transform.position.y) - actualPosition;
            actualPosition= transform.position;
            if(direction.x > 0f && direction.y >0f ||  direction.x > 0f && direction.y <0f )
                rigidbody.AddTorque(-0.5f);
            if(direction.x < 0f && direction.y >0f ||  direction.x < 0f && direction.y <0f )
                rigidbody.AddTorque(0.5f);
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
            GetComponent<Rigidbody2D>().velocity = (new Vector2(velocityX, velocityY));
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
