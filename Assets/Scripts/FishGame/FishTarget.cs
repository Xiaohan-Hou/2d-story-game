using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTarget: MonoBehaviour
{
    //Speed & Boundaries
    public float moveSpeed = 8.0f;
    private float leftLimit = -12;
    private float rightLimit = 12;

    //Script communication
    private FishScoreManager fishScoreManager;
    private FishGameManager fishGameManagerScript;
    private FishSoundManager fishSoundManager;
    
    void Start()
    {
        //Script communication
        fishScoreManager = GameObject.Find("ScoreManager").GetComponent<FishScoreManager>();
        fishGameManagerScript = GameObject.Find("GameManager").GetComponent<FishGameManager>();
        fishSoundManager = GameObject.Find("SFXManager").GetComponent<FishSoundManager>();
    }

   
    void Update()
    {
        if(fishGameManagerScript.isGameActive)
        {
            Move();
            DestoryOutOfBound();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Targets move
    void Move()
    {
        if(gameObject.CompareTag("FishLeft") || gameObject.CompareTag("Snake"))
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        else if(gameObject.CompareTag("FishRight") || gameObject.CompareTag("JellyFish"))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }

    //Destroy when out of the boundary
    void DestoryOutOfBound()
    {
        if(gameObject.transform.position.x<leftLimit || gameObject.transform.position.x > rightLimit)
        {
            Destroy(gameObject);
        }
    }

    //When clicking
    void OnMouseDown()
    {
        //Destroy targets
        Destroy(gameObject);

        //If clicking with the good targets
        if(gameObject.CompareTag("FishLeft") || gameObject.CompareTag("FishRight"))
        {
            fishSoundManager.PlayCollectionSound();
            fishScoreManager.UpdateScore(1);
        }
        //If clicking with the bad targets
        else if (gameObject.CompareTag("Snake") || gameObject.CompareTag("JellyFish"))
        {
            fishSoundManager.PlayAccidentalCollisionSound();
            fishGameManagerScript.GameOverFailed();
        }
    }
}
