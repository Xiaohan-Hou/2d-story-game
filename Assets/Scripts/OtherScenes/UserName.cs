using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UserName : MonoBehaviour
{
    public static string userName;
    public TMP_InputField inputField;

    public void GetUserName()
    {
        userName = inputField.GetComponent<TMP_InputField>().text;
    }

}
