using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DinnerDialogueManager : MonoBehaviour
{
    //Getting reference
    public TextMeshProUGUI textDisplay;

    //Buttons & Panel
    public GameObject continueButton;
    public GameObject option1Button;
    public GameObject option2Button;
    public GameObject thanksButton;
    public GameObject byeButton;
    public GameObject PanelUI;

    //Food image
    public GameObject option1Image;
    public GameObject option2Image;

    //Sentence array
    [TextArea(3, 8)]
    public string[] sentences;
    private int index;

    //Indicate which option
    private string optionIndiactor;

    //Typing speed
    public float textSpeed = 0.05f;

    void Start()
    {
        textDisplay.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        //Checking the status of sentence typing to display buttons and images
        if (textDisplay.text == sentences[0]) //Display first sentence
        {
            continueButton.SetActive(true);
        }
        else if (textDisplay.text == sentences[1]) //Ask for options
        {
            option1Button.SetActive(true);
            option2Button.SetActive(true);
        }
        else if (textDisplay.text == sentences[2]) //"Here you go!" & display chosen dinner combo
        {
            if(optionIndiactor == "option1")
            {
                option1Image.SetActive(true);
            }
            else if(optionIndiactor == "option2") 
            {
                option2Image.SetActive(true);
            }

            thanksButton.SetActive(true);
            
        }
        else if (textDisplay.text == sentences[3]) //Goodbye message
        {
            byeButton.SetActive(true);
        }
    }

    IEnumerator TypeLine()
    {
        //Breaking down the characters in a sentence to an array
        char[] charArray = sentences[index].ToCharArray();

        //Lopping through the array
        foreach (char c in charArray)
        {
            textDisplay.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void DisplayNextSentence()
    {
        //UI
        continueButton.SetActive(false);
        thanksButton.SetActive(false);
        option1Image.SetActive(false);
        option2Image.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    public void DisplayOption1()
    {
        optionIndiactor = "option1";
        DisplayOptionText();
    }

    public void DisplayOption2()
    {
        optionIndiactor = "option2";
        DisplayOptionText();
    }

    public void DisplayOptionText()
    {
        //UI
        option1Button.SetActive(false);
        option2Button.SetActive(false);

        //Text Line
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
}
