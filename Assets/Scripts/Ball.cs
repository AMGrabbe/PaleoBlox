
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddleOne;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] ballSound;
    [SerializeField] float randomFactor = 0.2f;



    Vector2 distance;
    bool hasStarted = false;
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2d;
    Vector2 actualPosition;


    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - paddleOne.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2d = GetComponent<Rigidbody2D>();
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
                myRigidBody2d.AddTorque(-0.5f);
            if(direction.x < 0f && direction.y >0f ||  direction.x < 0f && direction.y <0f )
                myRigidBody2d.AddTorque(0.5f);
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
            myRigidBody2d.velocity = (new Vector2(velocityX, velocityY));
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float randomAngle = Random.Range(-randomFactor, randomFactor);
        
        if (hasStarted)
        {
            AudioClip clip = ballSound[UnityEngine.Random.Range(0, ballSound.Length)];
            myAudioSource.PlayOneShot(clip);
            //Essentially "Quaternion.Euler(0, 0, randomAngle)" says "rotate by randomAngle around the z axis and by 0 around the x and y axes".
            myRigidBody2d.velocity = Quaternion.Euler(0, 0, randomAngle) * myRigidBody2d.velocity;;
        }

    }
}
