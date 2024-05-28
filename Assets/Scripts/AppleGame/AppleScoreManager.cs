using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppleScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private AppleGameManager appleGameManager;
    private int score;
   
    void Start()
    {
        //Script communication
        appleGameManager = GameObject.Find("GameManager").GetComponent<AppleGameManager>();

        //5 apples before starting
        UpdateScore(5);
    }

    void Update()
    {
        //Clear scores to zero if it is less than 0
        if(score <= 0)
        {
            DownToZero();
            appleGameManager.GameOverFailed();
        }

        //Succeed when hitting 15
        else if(score >= 15)
        {
            appleGameManager.GameOverSuccess();
        }
    }

    //Store score and display UI
    public void UpdateScore(int point)
    {
        score = score + point;
        scoreText.text = "<color=#D91C0B>" + score.ToString() + "</color>" + "/15";
    }

    public void DownToZero()
    {
        score = 0;
        scoreText.text = "<color=#D91C0B>" + score.ToString() + "</color>" + "/15";
    }
}
