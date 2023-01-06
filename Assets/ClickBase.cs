using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class ClickBase : MonoBehaviour
{
    //This class is the base for all clickable items,

    [SerializeField] protected string Tag;
    [SerializeField] protected GameObject CanvasElement;
    protected bool QuestionAsked; 


    private GameObject selectedObject;
    private ButtonControl leftButton;

    private void Awake()
    {
        leftButton = Mouse.current.leftButton;
        QuestionAsked = false; 
    }

    protected virtual void CheckClick()
    {
        if (leftButton.wasPressedThisFrame)
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag(Tag))
                    {
                        return;
                    }
                    selectedObject = hit.collider.gameObject;
                   
                }
            }
            else
            {
                
                selectedObject = null;
                Cursor.visible = true;
            }
        }
        if (selectedObject != null)
        {
            
            if (QuestionAsked == false && !CanvasElement.activeInHierarchy)
            {
                CanvasElement.SetActive(true);
            }
            
        }
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
