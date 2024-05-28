using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUI: MonoBehaviour
{
    public GameObject contentUI;

    public void CloseUIOnClick()
    {
        contentUI.SetActive(false);
    }
}
