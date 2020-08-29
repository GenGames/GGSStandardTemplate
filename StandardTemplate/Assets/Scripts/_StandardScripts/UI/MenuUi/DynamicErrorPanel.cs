using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class DynamicErrorPanel : MonoBehaviour
{
    #region Singleton

    public static DynamicErrorPanel instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Action myAction;
    public Text errorDescriptionText;
    public GameObject errorPanel;

    private void Start()
    {
        errorPanel.SetActive(false);
    }

    // **EXAMPLE/SETUP LIKE SO**
    // DynamicErrorPanel.instance.myAction += [enter callback function without inputs or paranthesis here];
    // DynamicErrorPanel.instance.ActivateErrorPanel ([description of the error and the action taken here, if you don't know, just put "are you sure?"]);
    //
    // (if you want to stop the function, include)
    // "return;"

    public void ActivateErrorPanel(string errorDescription)
    {
        errorPanel.SetActive(true);
        errorDescriptionText.text = errorDescription;

        //sfx for error popup here
    }

    public void DeactivateErrorPanel()
    {
        errorPanel.SetActive(false);

        // sfx for close menu here
    }

    public void PerformAction()
    {
        myAction();
        ClearAction();
        //sfx for button accepted here
    }

    public void ClearAction()
    {
        myAction = null;
    }
}
