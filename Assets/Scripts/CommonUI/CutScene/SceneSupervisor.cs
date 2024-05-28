using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSupervisor : MonoBehaviour
{
    //Scene 1
    public void LoadGameHome()
    {
        SceneManager.LoadScene("1_GameHome");
        AudioSource gameGeneralMusic = GameObject.Find("GameGeneralMusic").GetComponent<AudioSource>();
        gameGeneralMusic.Play();
    }

    //Scene 2
    public void LoadGameGuideScene()
    {
        StartCoroutine(DelaySceneLoading("2_GameGuide"));
    }

    //Scene 3
    public void LoadGetReadyScene()
    {
        StartCoroutine(DelaySceneLoading("3_GetReadyScene"));

        //No longer need forest ambience
        Destroy(GameObject.Find("ForestAmbience"));
    }

    //Scene 4
    public void LoadForestScene()
    {
        SceneManager.LoadScene("4_ForestScene");
    }

    //Scene 5
    public void LoadAppleGameMenu()
    {
        SceneManager.LoadScene("5_AppleGameMenu");

        //Pausing game general music
        if(GameObject.Find("GameGeneralMusic") != null)
        {
            AudioSource gameIntroAudioSource = GameObject.Find("GameGeneralMusic").GetComponent<AudioSource>();
            gameIntroAudioSource.Pause();
        } 
    }

    //Scene 6
    public void LoadAppleGameInstruction()
    {
        SceneManager.LoadScene("6_AppleGameInstruction");
    }

    //Scene 7
    public void LoadAppleGamePlay()
    {
        SceneManager.LoadScene("7_AppleGamePlay");

        //For restarting purpose
        if(GameObject.Find("AppleMusic") != null)
        {
            AudioSource appleAudioSource = GameObject.Find("AppleMusic").GetComponent<AudioSource>();
            appleAudioSource.mute = false;
        }
    }

    //Scene 8
    public void LoadAppleAppleGameOverSuccess()
    {
        SceneManager.LoadScene("8_AppleGameOverSuccess");

        //No longer need apple mumsic
        if (GameObject.Find("AppleMusic") != null)
        {
            Destroy(GameObject.Find("AppleMusic"));
        }
    }

    //Scene 9
    public void LoadAppleAppleGameOverFailed()
    {
        SceneManager.LoadScene("9_AppleGameOverLose");

        //Mute the audio for the SFX
        if (GameObject.Find("AppleMusic") != null)
        {
            AudioSource appleAudioSource = GameObject.Find("AppleMusic").GetComponent<AudioSource>();
            appleAudioSource.mute = true;
        }
    }

    //Scene 10
    public void LoadForesttoFish()
    {
        SceneManager.LoadScene("10_ForestToRiver");

        //Continue playing game general music
        if(GameObject.Find("GameGeneralMusic") != null)
        {
            AudioSource gameIntroAudioSource = GameObject.Find("GameGeneralMusic").GetComponent<AudioSource>();
            gameIntroAudioSource.Play();
        }
       
    }

    //Scene 11
    public void LoadFishGameMenu()
    {
        SceneManager.LoadScene("11_FishGameMenu");
    }

    //Scene 12
    public void LoadFishGameInstruction()
    {
        SceneManager.LoadScene("12_FishGameInstruction");
    }

    //Scene 13
    public void LoadFishGamePlay()
    {
        SceneManager.LoadScene("13_FishGamePlay");

        //Pausing the game general music
        if(GameObject.Find("GameGeneralMusic") != null)
        {
            AudioSource gameIntroAudioSource = GameObject.Find("GameGeneralMusic").GetComponent<AudioSource>();
            gameIntroAudioSource.Pause();
        }

        //For restart situation
        if(GameObject.Find("FishMusic") != null)
        {
            AudioSource fishMusicAudioSource = GameObject.Find("FishMusic").GetComponent<AudioSource>();
            fishMusicAudioSource.mute = false;
        }
    }

    //Scene 14
    public void LoadFishGameOver()
    {
        SceneManager.LoadScene("14_FishGameOver");

        //No longer need fish game music
        if((GameObject.Find("FishMusic") != null))
        {
            Destroy(GameObject.Find("FishMusic"));
        } 
    }

    //Scene 15
    public void LoadDinnerScene()
    {
        SceneManager.LoadScene("15_DinnerScene");

        //No longer need river ambience
        if (GameObject.Find("RiverAmbience") != null)
        {
            Destroy(GameObject.Find("RiverAmbience"));
        }

        //Continue playing game general music
        if(GameObject.Find("GameGeneralMusic") !=null)
        {
            AudioSource gameIntroAudioSource = GameObject.Find("GameGeneralMusic").GetComponent<AudioSource>();
            gameIntroAudioSource.Play();
        }
    }

    //Delay cut scene for clicking sound
    IEnumerator DelaySceneLoading(string scenename)
    {
        yield return new WaitForSeconds(0.183f);
        SceneManager.LoadScene(scenename);
    }
}
