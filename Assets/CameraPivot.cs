using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPivot : MonoBehaviour
{
    //Movement Speed and Time for the camera
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float movementTime;
    [SerializeField]
    private float rotationAmount;


    [SerializeField]
    private PlayerInput playerInput; //Player input component


    private Vector3 newPosition;
    private Quaternion newRotation;

    [SerializeField]
    private Transform cameraTransform;

    private Vector3 zoomAmount;
    private Vector3 newZoom;



    private void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
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
        var camRotateLeft = playerInput.actions["CameraRotateLeft"];
        var camRotateRight = playerInput.actions["CameraRotateRight"];

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

        if (camRotateLeft.IsPressed())
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (camRotateRight.IsPressed())
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
    }
}
