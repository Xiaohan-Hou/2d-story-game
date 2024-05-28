using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestAmbience : MonoBehaviour
{
    private static ForestAmbience forestAmbienceInstance;

    void Awake()
    {
        //Avoid two game objects when going back and force
        if (forestAmbienceInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            forestAmbienceInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
