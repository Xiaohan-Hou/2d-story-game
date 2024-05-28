using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishScoreManager : MonoBehaviour
{
    //Getting reference & script communication
    public TextMeshProUGUI fishText;
    public TextMeshProUGUI timeText;
    private FishGameManager fishGameManager;

    //Score & Time
    private int score;
    public static int scoreForNextScene;
    private float time = 30;

    void Start()
    {
        UpdateScore(0);

        //Script communication
        fishGameManager = GameObject.Find("GameManager").GetComponent<FishGameManager>();
    }

    void Update()
    {
        //Store the "score" for next scene display
        scoreForNextScene = score;

        //Timer
        if(fishGameManager.isGameActive)
        {
            time = time - Time.deltaTime;
            timeText.text = Mathf.Round(time).ToString();
        }

        if (time <= 0)
        {
            fishGameManager.GameOverSuccess();
        }
    }

    //Updating score
    public void UpdateScore(int point)
    {
        score = score + point;
        fishText.text = score.ToString();
    }
}
