using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartGame : MonoBehaviour
{
    private SceneSupervisor sceneSupervisor;

    void Start()
    {
        sceneSupervisor = GameObject.Find("SceneManager").GetComponent<SceneSupervisor>();
    }

    public void Restart()
    {
        sceneSupervisor.LoadGameHome();
    }
}
