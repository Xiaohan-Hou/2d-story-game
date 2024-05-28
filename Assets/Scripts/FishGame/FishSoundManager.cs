using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSoundManager : MonoBehaviour
{
    private AudioSource fishAudioSource;

    public AudioClip collectionSFX;
    public AudioClip accidentalCollisionSFX;

    void Start()
    {
        //Getting Audio Source
        fishAudioSource = GetComponent<AudioSource>();
    }

    public void PlayCollectionSound()
    {
        fishAudioSource.PlayOneShot(collectionSFX);
    }

    public void PlayAccidentalCollisionSound()
    {
        fishAudioSource.PlayOneShot(accidentalCollisionSFX);
    }
}
