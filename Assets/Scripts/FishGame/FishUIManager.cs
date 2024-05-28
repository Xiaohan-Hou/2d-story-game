using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishUIManager : MonoBehaviour
{
    //Getting reference & Script communication
    public GameObject fishDialogueManager;
    private DialogueManager dialogueManagerScript;

    void Start()
    {
        //Script communication
        dialogueManagerScript = fishDialogueManager.GetComponent<DialogueManager>();
        ReplaceString();
    }

    void ReplaceString()
    {
        //Replace it with fish amount
        dialogueManagerScript.sentences[0] = dialogueManagerScript.sentences[0].Replace("&num", FishScoreManager.scoreForNextScene.ToString());
    }
}
