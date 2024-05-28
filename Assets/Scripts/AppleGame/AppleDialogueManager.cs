using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppleDialogueManager : MonoBehaviour
{
    //Buttons & Text
    public TextMeshProUGUI textDisplay;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    //Text array
    [TextArea(3, 8)]
    public string[] sentences;
    private int index;

    //Typing speed
    public float textSpeed = 0.01f;

    void Start()
    {
        //Clear
        textDisplay.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    //Checking the status of typing
    void Update()
    {
        if (textDisplay.text == sentences[0])
        {
            button1.SetActive(true);
        }
        else if (textDisplay.text == sentences[1])
        {
            button2.SetActive(true);
            button3.SetActive(true);
        }
    }

    //Typing effect
    IEnumerator TypeLine()
    {
        //Breaking down the sentence to a char array
        char[] charArray = sentences[index].ToCharArray();

        //Lopping through the array
        foreach (char c in charArray)
        {
            textDisplay.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    //Display next sentence
    public void DisplayNextSentence()
    {
        button1.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
}
