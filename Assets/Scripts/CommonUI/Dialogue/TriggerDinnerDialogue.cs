using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDinnerDialogue : MonoBehaviour
{
    public GameObject panelUI;
    public DinnerDialogueManager dinnerDialogueManager;

    //Show after animation is over
    public void TriggerDialogueAfterAnimation()
    {
        panelUI.SetActive(true);
        dinnerDialogueManager.enabled = true;
    }
}
