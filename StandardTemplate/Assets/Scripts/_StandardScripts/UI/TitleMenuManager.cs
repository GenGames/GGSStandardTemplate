using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitleMenuManager : MonoBehaviour
{
    private Keyboard keyboard;

    private void Start()
    {
        keyboard = InputSystem.GetDevice<Keyboard>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboard.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        } 
        else if (keyboard.anyKey.wasPressedThisFrame)
        {
            GameManager.instance.GoToSceneName("LevelSelection");
        }
    }
}
