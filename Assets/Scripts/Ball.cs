
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] ballSound;

    Vector2 ballPaddleDistance;
    bool hasStarted = false;
    AudioSource myAudioSource;
    Rigidbody2D rigidBody;
    Vector2 actualPosition;
    
    void Start()
    {
        ballPaddleDistance = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
        actualPosition = transform.position;
    }

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
        }  
    }


    /*
    if balls moving direction goes to right side of the screen rotate clockwise 
    else rotate counter clockwise
    */
    private void ManageBallRotationDirection(Vector2 direction)
    {
        if(direction.x > 0f)
        {
            rigidBody.AddTorque(-0.5f);
        }
        else
        {
            rigidBody.AddTorque(0.1f);
        }
    }

    private void StickBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + ballPaddleDistance;
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidBody.velocity = (new Vector2(velocityX, velocityY));
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip randomSoundClip = ballSound[UnityEngine.Random.Range(0, ballSound.Length)];
            myAudioSource.PlayOneShot(randomSoundClip);
            Vector2 direction = new Vector2(transform.position.x, transform.position.y) - actualPosition;
        }

    }
}
