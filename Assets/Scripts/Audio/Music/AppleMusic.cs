using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleMusic : MonoBehaviour
{
    private static AppleMusic appleMusicInstance;

    void Awake()
    {
        //Avoid two game objects when going back and force
        if (appleMusicInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            appleMusicInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
