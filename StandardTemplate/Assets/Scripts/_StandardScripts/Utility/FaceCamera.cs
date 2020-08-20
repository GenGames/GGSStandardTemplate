using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Camera cameraToFace;

    private void Start()
    {
        if (cameraToFace == null)
        {
            cameraToFace = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraToFace != null)
        {
            transform.LookAt(cameraToFace.transform);

        }
    }
}
