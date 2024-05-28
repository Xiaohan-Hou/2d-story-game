using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGameTargets : MonoBehaviour
{
    //Speed of target moving
    public float targetMoveSpeed = 5.0f;

    //Accessing player's position for checking if the targets have gone the bear
    private Transform playerTransform;

    //Script communication
    private AppleScoreManager appleScoreManager;
    private AppleGameManager appleGameManager;
    private AppleUIManager appleUIManager;

    void Start()
    {
        //Script communication
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        appleScoreManager = GameObject.Find("ScoreManager").GetComponent<AppleScoreManager>();
        appleGameManager = GameObject.Find("GameManager").GetComponent<AppleGameManager>();
        appleUIManager = appleUIManager = GameObject.Find("UIManager").GetComponent<AppleUIManager>();
    }

    void Update()
    {
        if(appleGameManager.isGameActive)
        {
            TargetMove();
            DetectTargets();
        }else {
            //Make all the targets disappear once the play is over
            Destroy(gameObject);
        }
    }

    //Targets move
    void TargetMove()
    {
        transform.Translate(Vector2.down * targetMoveSpeed * Time.deltaTime);
    }

    //Detect if the targets have gone pass the bear
    void DetectTargets()
    {
        //If bad targets go pass the player
        if (gameObject.CompareTag("Enemy") && transform.position.y < playerTransform.position.y)
        {
            StartCoroutine(appleUIManager.ShowBubble("Oops!", 1));
            appleScoreManager.UpdateScore(-1);
            Destroy(gameObject);
        //If apples go pass the player
        }else if(gameObject.CompareTag("Goods") && transform.position.y < playerTransform.position.y)
        {
            Destroy(gameObject);
        }
    }
}