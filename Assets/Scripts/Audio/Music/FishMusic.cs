using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMusic : MonoBehaviour
{
    private static FishMusic fishMusicInstance;

    void Awake()
    {
        //Avoid two game objects when going back and force
        if (fishMusicInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            fishMusicInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
