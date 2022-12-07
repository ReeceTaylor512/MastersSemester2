using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Grabber : MonoBehaviour
{
    private GameObject selectedObject;
    private ButtonControl leftButton = Mouse.current.leftButton;
    [SerializeField][Header("How much do we want an object to lift off the ground when it is grabbed")]
    private float lift; 

    // Update is called once per frame
    void Update()
    {
        if (leftButton.wasPressedThisFrame)
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if(hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Drag"))
                    {
                        return;
                    }
                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false; 
                }
            }
            else
            {
                SetObjectPosition(0);
                selectedObject = null;
                Cursor.visible = true;
            }
        }
        if (selectedObject != null)
        {
            SetObjectPosition(lift);
        }
    }

    private void SetObjectPosition(float yPos)
    {
        Vector3 pos = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
        selectedObject.transform.position = new Vector3(worldPos.x, yPos, worldPos.z);
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3
            (
            Mouse.current.position.ReadValue().x,
            Mouse.current.position.ReadValue().y,
            Camera.main.farClipPlane
            );
        Vector3 screenMousePosNear = new Vector3
            (
            Mouse.current.position.ReadValue().x,
            Mouse.current.position.ReadValue().y,
            Camera.main.nearClipPlane
            );
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
