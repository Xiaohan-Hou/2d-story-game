using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceUserName : MonoBehaviour
{
    public GameObject getReadyDialogueManager;
    public DialogueManager dialogueManagerScript;

    void Start()
    {
        //Script Communication
        dialogueManagerScript = getReadyDialogueManager.GetComponent<DialogueManager>();

        ReplaceString();
    }

    void ReplaceString()
    {
        //Checking input in case the user has entered anything
        if (UserName.userName == null || UserName.userName == "")
        {
            UserName.userName = "Player";
        }

        //Replace it with user name
        dialogueManagerScript.sentences[0] = dialogueManagerScript.sentences[0].Replace("&name", UserName.userName);
    }
}
