using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGameManager : MonoBehaviour
{
    //Game status
    public bool isGameActive;

    //Getting reference
    public GameObject gameOverFailedUI;

    //Script communication
    private FishScoreManager fishScoreManager;
    private FishSpawnManager fishSpawnManager;
    private SceneSupervisor sceneSupervisor;

    void Start()
    {
        //Script Communication
        fishSpawnManager = GameObject.Find("SpawnManager").GetComponent<FishSpawnManager>();
        fishScoreManager = GameObject.Find("ScoreManager").GetComponent<FishScoreManager>();
        sceneSupervisor = GameObject.Find("SceneManager").GetComponent<SceneSupervisor>();

        //Start Game
        isGameActive = true;
        StartCoroutine(fishSpawnManager.SpawnLeftTargets());
        StartCoroutine(fishSpawnManager.SpawnRightTargets());
    }

    public void GameOverSuccess()
    {
        isGameActive = false;
        sceneSupervisor.LoadFishGameOver();
    }

    public void GameOverFailed()
    {
        isGameActive = false;
        StartCoroutine(DelayGameOverFailed());

        //Mute for game over SFX
        AudioSource fishMusicAudioSource = GameObject.Find("FishMusic").GetComponent<AudioSource>();
        fishMusicAudioSource.mute = true;
    }

    IEnumerator DelayGameOverFailed()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverFailedUI.SetActive(true);
    }
}
