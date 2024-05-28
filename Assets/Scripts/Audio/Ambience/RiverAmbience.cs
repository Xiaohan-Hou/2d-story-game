using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverAmbience : MonoBehaviour
{
    private static RiverAmbience riverAmbienceInstance;

    void Awake()
    {
        //Avoid two game objects when going back and force
        if (riverAmbienceInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            riverAmbienceInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
