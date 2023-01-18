using UnityEngine;

public class SphereScript : MonoBehaviour, IDrag 
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void onEndDrag()
    {
        rb.useGravity = true;
        //Constraints the object so it does not move after being dropped
        rb.constraints = RigidbodyConstraints.FreezeAll;
        Cursor.visible = true;


    }

    public void onStartDrag()
    {
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        Cursor.visible = false;
    }
}
