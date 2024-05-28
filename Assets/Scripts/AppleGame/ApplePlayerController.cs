using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePlayerController : MonoBehaviour
{ 
    //Relevant variables for moving the player
    private float horizontalInput;

    private float leftLimit = -7.0f;
    private float rightLimit = 7.0f;

    public float playerSpeed = 20.0f;

    //Script communication
    public GameObject bullet;
    private AppleScoreManager appleScoreManager;
    private AppleGameManager appleGameManager;
    private AppleSoundManager appleSoundManager;
    private AppleUIManager appleUIManager;

    void Start()
    {
        //Script communication
        appleScoreManager = GameObject.Find("ScoreManager").GetComponent<AppleScoreManager>();
        appleGameManager = GameObject.Find("GameManager").GetComponent<AppleGameManager>();
        appleSoundManager = GameObject.Find("SFXManager").GetComponent<AppleSoundManager>();
        appleUIManager = GameObject.Find("UIManager").GetComponent<AppleUIManager>();
    }

    void Update()
    {
        movePlayer();

        //Pressing space bar results in sending bullet
        if (appleGameManager.isGameActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendBullet();
            };
        }
    }

    //Player movement through keyboard
    void movePlayer()
    {
        //Player can be moved during the countdown
        if(appleGameManager.isPlayerActive || appleGameManager.isGameActive )
        {
            //Get keyboard input and move player
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * Time.deltaTime * playerSpeed * horizontalInput);

            //Detecting left limit
            if (transform.position.x < leftLimit)
            {
                transform.position = new Vector2(leftLimit, transform.position.y);
            }

            //Detecting right limit
            if (transform.position.x > rightLimit)
            {
                transform.position = new Vector2(rightLimit, transform.position.y);
            }
        }
    }

    //Buellet
    void SendBullet()
    {
        Instantiate(bullet, transform.position, bullet.transform.rotation); ;
    }

    //Colliding with good or bad targets
    void OnTriggerEnter2D(Collider2D other)
    {
        //Collecting apples
        if (other.CompareTag("Goods"))
        {
            //Play sound
            appleSoundManager.PlayCollectingSFX();

            //Display UI and update score
            StartCoroutine(appleUIManager.ShowBubble("Yay!", 1));
            appleScoreManager.UpdateScore(1);

            //Destroy
            Destroy(other.gameObject);
        }
        //Colliding with bad targets
        else if (other.CompareTag("Enemy"))
        {
            //Play sound
            appleSoundManager.PlayAccidentalCllisionSFX();

            //Display UI and update score
            StartCoroutine(appleUIManager.ShowBubble("Oops!", 1));
            appleScoreManager.UpdateScore(-2);

            //Destroy
            Destroy(other.gameObject);
        }
    }
}
