using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Drag : MonoBehaviour
{
    public GameObject stethascope;
    public BoxCollider BCollider;
    public AudioSource Audio;
    private float mZCoord;
    public static Drag instance;
    public float xCoord;
    private void Start()
    {
        xCoord = 1.3717f;          
    }

    void OnMouseDown()
    {
        // Store offset = gameobject world pos - mouse world pos        
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Cursor.visible = false;
        stethascope.SetActive(false);
    }
    private Vector3 GetMouseWorldPos() 
    {
        // pixel coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        transform.position = new Vector3 (GetMouseWorldPos().x, xCoord, (GetMouseWorldPos() * 1.8f).z);
    }
    private void OnMouseUp()
    {
        transform.position = new Vector3(0, 1.3717f, 0);
        stethascope.SetActive(true);
        Cursor.visible = true;
    }         
    private void OnTriggerEnter(Collider Coll)
    {
        Debug.Log(Coll.gameObject.tag);
        if (Coll.gameObject.CompareTag("AudioCollider"))
        {
            Audio.Play();
            Debug.Log("colision");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Audio.Stop();
    }    
}