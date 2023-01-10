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
    }

    public void onStartDrag()
    {
        rb.useGravity = false; 
    }
}
