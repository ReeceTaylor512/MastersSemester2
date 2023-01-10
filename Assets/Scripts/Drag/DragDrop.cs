using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragDrop : MonoBehaviour
{
    [SerializeField]
    private InputAction mouseClick;

    private Camera mainCamera;

    [SerializeField] private float mouseDragPhysicsSpeed = 10;
    [SerializeField] private float mouseDragSpeed = 0.1f; //this changes the amount of drag the object has in relation to the mouse, reduce it to make the drag faster 

    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
    
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        mainCamera = Camera.main; 
    }

    //Basically enables the mouse when this script activates
    private void OnEnable()
    {
        mouseClick.Enable();
        mouseClick.performed += MousePressed; 
    }

    //Basically disables the mouse when this script deactivates
    private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        mouseClick.Disable(); 
    }

    private void MousePressed(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit; 
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && (hit.collider.gameObject.CompareTag("Draggable") || 
                hit.collider.gameObject.layer == LayerMask.NameToLayer("Draggable") || 
                hit.collider.gameObject.GetComponent<IDrag>() != null))
            {
                StartCoroutine(DragUpdate(hit.collider.gameObject));
            }
        }
    }

    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        clickedObject.TryGetComponent<Rigidbody>(out var rb); 
        clickedObject.TryGetComponent<IDrag>(out var iDragComponent);
        iDragComponent?.onStartDrag();
        
        float initDistance = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position); 

        
        while(mouseClick.ReadValue<float>() != 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if(rb != null)
            {
                Vector3 direction = ray.GetPoint(initDistance) - clickedObject.transform.position;
                rb.velocity = direction * mouseDragPhysicsSpeed;
                yield return waitForFixedUpdate; 
            }
            else
            {
                clickedObject.transform.position = Vector3.SmoothDamp
                    (clickedObject.transform.position, ray.GetPoint(initDistance), ref velocity, mouseDragSpeed);
                yield return null;
            }
        }
        iDragComponent?.onEndDrag();
    }
}
