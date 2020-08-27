using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointAndClickController : MonoBehaviour
{
    // place this on the camera that you want to be using as the point to click player

    public Camera cameraOfOrigin; // holds camera info
    private Mouse mouse;

    private void Start()
    {
        mouse = InputSystem.GetDevice<Mouse>();
        if (cameraOfOrigin == null && GetComponent<Camera>() != null) // gets the camera if the dev hasn't already set it and there is a camera on the current object
        {
            cameraOfOrigin = GetComponent<Camera>();
        }
    }

    private void Update()
    {
        if (mouse.leftButton.wasPressedThisFrame) // on click, cast ray and detect hit
        {
            Ray ray = cameraOfOrigin.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.GetComponent<PointAndClickTarget>() != null)
            {
                hit.transform.GetComponent<PointAndClickTarget>().Interacting();
            }
        }
    }
}
