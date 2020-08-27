using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3DFP : MonoBehaviour
{
    [Range(.1f,20)]
    public float moveSpeed = 7f;
    [Range(.1f,5)]
    public float xAxisLookSensitivity = 2.5f;
    [Range(.1f,5)]
    public float yAxisLookSensitivity = 2.5f;
    public InputMaster controls;
    private Vector2 _movement;
    private Transform head;
    [Range(15,89)]
    public float headRotationClamp = 80;

    private void Awake()
    {
        head = GetComponentInChildren<Camera>().transform;
        controls = new InputMaster();
        controls.Enable();
        controls.Player3DFP.Movement.performed += context => Move(context.ReadValue<Vector2>());
        controls.Player3DFP.Rotation.performed += context => Rotate(context.ReadValue<Vector2>());
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(_movement.x,0,_movement.y) * Time.deltaTime * moveSpeed);
    }

    public void Move(Vector2 direction)
    {
        _movement = direction;
    }

    public void Rotate(Vector2 rotationDirection)
    {
        head.Rotate(-rotationDirection.y * Time.deltaTime * yAxisLookSensitivity, 0, 0);

        if (head.localEulerAngles.x > headRotationClamp && head.localEulerAngles.x < 180)
        {
            head.localEulerAngles = new Vector3(headRotationClamp, 0, 0);
        } 
        else if (head.localEulerAngles.x < 360-headRotationClamp && head.localEulerAngles.x > 180)
        {
            head.localEulerAngles = new Vector3(360-headRotationClamp, 0, 0);
        }


        transform.Rotate(0, rotationDirection.x * Time.deltaTime * yAxisLookSensitivity, 0);
    }

    public void Jump()
    {
        // If you would like jumping, feel free to insert that here
    }



    private void OnDisable()
    {
        controls.Disable();
    }

    private void OnEnable()
    {
        controls.Enable();
    }
}
