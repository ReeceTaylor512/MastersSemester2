using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPivot : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float movementTime;

    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField]
    private Vector3 newPosition;

    private void Start()
    {
        newPosition = transform.position;

    }

    private void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        var cameraUp = playerInput.actions["cameraUp"];
        var cameraDown = playerInput.actions["cameraDown"];
        var cameraLeft = playerInput.actions["cameraLeft"];
        var cameraRight = playerInput.actions["cameraRight"];

        if (cameraUp.IsPressed())
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (cameraDown.IsPressed())
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if (cameraLeft.IsPressed())
        {
            newPosition += (transform.right * -movementSpeed);
        }
        if (cameraRight.IsPressed())
        {
            newPosition += (transform.right * movementSpeed);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
    }
}
