using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMusic : MonoBehaviour
{
    private static GeneralMusic generalMusicInstance;

    void Awake()
    {
        //Avoid two game objects when going back and force
        if (generalMusicInstance != null)
        {
            Destroy(gameObject);
        }else
        {
            generalMusicInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
