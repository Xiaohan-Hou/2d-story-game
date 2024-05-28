using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGameManager : MonoBehaviour
{
    //Game status bool
    public bool isPlayerActive;
    public bool isGameActive;

    //Script communication
    private AppleUIManager appleUIManager;
    private AppleSpawnManager appleSpawnManager;
    private AppleSoundManager appleSoundManager;
    private SceneSupervisor sceneSupervisor;

    void Start()
    {
        //Script communication
        appleSoundManager = GameObject.Find("SFXManager").GetComponent<AppleSoundManager>();
        appleUIManager = GameObject.Find("UIManager").GetComponent<AppleUIManager>();
        appleSpawnManager = GameObject.Find("SpawnManager").GetComponent<AppleSpawnManager>();
        sceneSupervisor = GameObject.Find("SceneManager").GetComponent<SceneSupervisor>();

        //Make player movable
        isPlayerActive = true;

        //Start to count down
        StartCoroutine(CountDown(6));
    }

    void StartGame()
    {
        //Setting the flag
        isGameActive = true;

        //Hide the bubble reminder of the bear & keep “go text" on the screen for a few more secs
        appleUIManager.BeforeGameStartPanelUI.SetActive(false);
        StartCoroutine(appleUIManager.KeepGoOnScreen(2));

        //Start to spawn targets
        StartCoroutine(appleSpawnManager.SpawnTargets());
    }

    //Counting down before starting the game
    IEnumerator CountDown(int count)
    {
        while (count>0)
        {
            yield return new WaitForSeconds(1);
            count--;
            appleSoundManager.PlayCountDownSFX();
            //Display text
            appleUIManager.countDownText.text = count.ToString();
        }

        //"Go" text
        appleSoundManager.PlayGoSFX();
        appleUIManager.countDownText.text = "Go!";

        //Start the whole function
        StartGame();
    }

    //Game over
    public void GameOverSuccess()
    {
        isGameActive = false;
        StartCoroutine(DelayGameOverSucces(1));
    }

    public void GameOverFailed()
    {
        isGameActive = false;
        StartCoroutine(DelayGameOverFailed(1));
    }

    //Delay cut scene
    IEnumerator DelayGameOverSucces(float time)
    {
        yield return new WaitForSeconds(time);
        sceneSupervisor.LoadAppleAppleGameOverSuccess();
    }

    IEnumerator DelayGameOverFailed(float time)
    {
        yield return new WaitForSeconds(time);
        sceneSupervisor.LoadAppleAppleGameOverFailed();
    }
}
