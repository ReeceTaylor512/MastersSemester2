
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskCheck : MonoBehaviour
{
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Mask")
        {
            DragDrop.ObjectInBounds = true;
            Debug.Log("ObjectInBounds");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Mask")
        {
            DragDrop.ObjectInBounds = false;
            Debug.Log("ObjectNotInBounds");
        }
    }
}
