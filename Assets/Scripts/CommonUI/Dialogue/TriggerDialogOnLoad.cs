using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogOnLoad : MonoBehaviour
{
    public GameObject panelUI;
    public DialogueManager dialoguemanager;
    private float waitTime = 2;

    void Start()
    {
        StartCoroutine(ShowAfterOnLoad());
    }

    IEnumerator ShowAfterOnLoad()
    {
        panelUI.SetActive(true);
        dialoguemanager.enabled = true;
        yield return new WaitForSeconds(waitTime);
    }

}
