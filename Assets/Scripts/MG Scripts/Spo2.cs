using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spo2 : MonoBehaviour
{    
    private float mZCoord;
    public GameObject wire1;
    public GameObject wire2;
    public static Drag instance;
    public float yCoord;
    bool connectionArea;
    Vector3 ConnectionAngles;
    public Text Spo2Readings;
    float ellapedTime;
    AudioSource clipsound;
    private void Start()
    {
        yCoord = 1.14859664f;
        ConnectionAngles = new Vector3 (270f, 339.12738f, 0f);
        clipsound = GetComponent<AudioSource>();
    }
    void OnMouseDown()
    {
        // Store offset = gameobject world pos - mouse world pos        
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Cursor.visible = false;
        transform.eulerAngles = ConnectionAngles;
        wire1.SetActive(false);
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
        transform.position = new Vector3(GetMouseWorldPos().x, yCoord, (GetMouseWorldPos() * 1.8f).z);
    }
    private void OnMouseUp()
    {
        if (connectionArea == true)
        {
            transform.position = new Vector3(-1.52059579f, 1.14859664f, -1.93203783f);
            transform.eulerAngles = new Vector3(270f, 339.12738f, 0f);
            wire2.SetActive(true);
            clipsound.Play();
            this.Wait(2f, Spo2Loading1);
        }
        else 
        {
            transform.position = new Vector3(-0.568783641f, 1.86256063f, 0.646833897f);
            transform.eulerAngles = new Vector3(356.4198f, 188.027115f, 178.025711f);
            wire1.SetActive(true);
        }
        
        Cursor.visible = true;

    }
    private void OnTriggerEnter(Collider Coll)
    {

        if (Coll.gameObject.CompareTag ("Spo2"))
        {
            connectionArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        connectionArea = false;
    }
    void SPO2Start() 
    {
        Spo2Readings.text = "SPo2 Rate: 98%";
    }

    void Spo2Loading1() 
    {
        if (ellapedTime != 5)
        {
            Spo2Readings.text = "Checking Spo2 --";
            ellapedTime++;
            this.Wait(1f, Spo2Loading2);
        }
        else
        {
            this.Wait(2f, SPO2Start);
        }
    }

    void Spo2Loading2()
    {
        if (ellapedTime != 5)
        {
            Spo2Readings.text = "Checking Spo2 :";
            ellapedTime++;
            this.Wait(1f, Spo2Loading1);
        }
        else 
        {
            this.Wait(2f, SPO2Start);
        }
    }
}
