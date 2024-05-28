using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogueAfterAnimation : MonoBehaviour
{
    public GameObject panelUI;
    public DialogueManager dialoguemanager;

    //Show dialogue box after the animation is over
    public void StartAfterAnimation()
    {
        //Make the panel visible
        panelUI.SetActive(true);

        //Enabling typing dialogue script once the animation is finished
        dialoguemanager.enabled = true;
    }
     
}
