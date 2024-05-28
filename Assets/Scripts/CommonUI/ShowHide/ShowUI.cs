using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject contentUI;

    public void DisplayUIOnClick()
    {
        contentUI.SetActive(true);
    }

}
