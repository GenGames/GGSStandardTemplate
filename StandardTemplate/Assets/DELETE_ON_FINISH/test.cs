using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class test : MonoBehaviour
{
    private Keyboard keyboard;
    private Mouse mouse;
    public EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        keyboard = InputSystem.GetDevice<Keyboard>();
        mouse = InputSystem.GetDevice<Mouse>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse.leftButton.wasPressedThisFrame)
        {
            print("mouse clicked...");
            print("" + eventSystem.IsPointerOverGameObject());
        }
    }
}
