using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSoundManager : MonoBehaviour
{
    private AudioSource gameAudioSource;

    //Audio Clip
    public AudioClip countDownSFX;
    public AudioClip goSFX;
    public AudioClip collectingSFX;
    public AudioClip bulletCollisionSFX;
    public AudioClip accidentalCollisionSFX;

    void Start()
    {
        //Getting Audio Source
        gameAudioSource = GetComponent<AudioSource>();
    }

    public void PlayCountDownSFX()
    {
        gameAudioSource.PlayOneShot(countDownSFX, 1.0f);
    }

    public void PlayGoSFX()
    {
        gameAudioSource.PlayOneShot(goSFX, 1.0f);
    }

    public void PlayCollectingSFX()
    {
       gameAudioSource.PlayOneShot(collectingSFX, 1.0f);
    }

    public void PlayBulletCollisionSFX()
    {
        gameAudioSource.PlayOneShot(bulletCollisionSFX, 1.0f);
    }

    public void PlayAccidentalCllisionSFX()
    {
        gameAudioSource.PlayOneShot(accidentalCollisionSFX, 1.0f);
    }
}
