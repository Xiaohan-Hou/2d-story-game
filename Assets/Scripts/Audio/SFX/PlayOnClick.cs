using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnClick : MonoBehaviour
{
    private AudioSource clickingAudioSource;
    public AudioClip clickingSound;

    void Start()
    {
        //Getting reference
        clickingAudioSource = GetComponent<AudioSource>();
    }

    public void PlaySFXonClick()
    {
        clickingAudioSource.PlayOneShot(clickingSound);
    }
}
