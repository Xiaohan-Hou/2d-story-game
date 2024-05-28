using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppleUIManager : MonoBehaviour
{
    //Start game preparation
    public GameObject BeforeGameStartPanelUI;
    public TextMeshProUGUI countDownText;

    //For the speech bubble
    public GameObject gamePlayBubbleUI;
    public TextMeshProUGUI bubbleText;

    //Keep the "Go" text on screen a bit longer and then disable it
    public IEnumerator KeepGoOnScreen(float time)
    {
        yield return new WaitForSeconds(time);
        countDownText.enabled = false;
    }

    //To display the speech bubble when gain/lose points and make them disappear after certain time
    public IEnumerator ShowBubble(string text, float time)
    {
        bubbleText.text = text;
        gamePlayBubbleUI.SetActive(true);
        yield return new WaitForSeconds(1);
        gamePlayBubbleUI.SetActive(false);
    }
}
