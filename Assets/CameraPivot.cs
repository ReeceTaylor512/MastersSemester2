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

    [SerializeField]
    private Vector3 zoomAmount;
    private Vector3 newZoom;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition; 

    private void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    private void Update()
    {
        HandleMouseInput();
        HandleMovementInput();
        
    }

    void HandleMouseInput()
    {
        var LeftMouseButton = playerInput.actions["LMB"];
        var RightMouseButton = playerInput.actions["RMB"];
        
        if (LeftMouseButton.WasPerformedThisFrame())
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            float entry;

            if(plane.Raycast(ray, out entry))
            {
                dragStartPosition = ray.GetPoint(entry);
            }
        }

        if (LeftMouseButton.IsPressed())
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPosition = ray.GetPoint(entry);

                newPosition = transform.position + dragStartPosition - dragCurrentPosition;
            }
        }


    }

    void HandleMovementInput()
    {
        //Local Variables which are assigned actions mappings
        var cameraUp = playerInput.actions["cameraUp"];
        var cameraDown = playerInput.actions["cameraDown"];
        var cameraLeft = playerInput.actions["cameraLeft"];
        var cameraRight = playerInput.actions["cameraRight"];
        var camRotateLeft = playerInput.actions["CameraRotateLeft"];
        var camRotateRight = playerInput.actions["CameraRotateRight"];
        var cameraZoomIn = playerInput.actions["CameraZoomIn"];
        var cameraZoomOut = playerInput.actions["CameraZoomOut"];
        


        //check if button is pressed and move camera accordingly
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
       

        //check if button is pressed and rotate camera accordingly
        if (camRotateLeft.IsPressed())
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (camRotateRight.IsPressed())
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        if (cameraZoomIn.IsPressed())
        {
            newZoom += zoomAmount;
        }
        if (cameraZoomOut.IsPressed())
        {
            newZoom -= zoomAmount;
        }

        //lerp between moving and rotating the camera
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime); 
    }
}
