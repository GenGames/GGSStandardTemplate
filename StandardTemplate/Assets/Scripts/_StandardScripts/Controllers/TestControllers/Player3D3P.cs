using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player3D3P : MonoBehaviour
{
    public InputMaster controls;
    [Range(0,20)]
    public float playerSpeed = 8f;
    private Vector2 _moveOutput;

    private void Awake()
    {
        controls = new InputMaster();
        controls.PlayerThreeDThirdPerson.Movement.performed += context => Move(context.ReadValue<Vector2>());
        controls.Enable();
    }

    private void FixedUpdate()
    {
        // basic movement translation
        transform.position += (new Vector3(_moveOutput.x, 0, _moveOutput.y) * playerSpeed * Time.deltaTime);
    }

    public void Move(Vector2 direction)
    {
        _moveOutput = direction;
    }

    private void OnEnable()
    {
        controls = new InputMaster();
        controls.Enable();
    }

    private void OnDisable()
    {
        controls = new InputMaster();
        controls.Disable();
    }
}
