using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickChecker : MonoBehaviour
{
    public GameObject Bed1;
    public GameObject Bed2;
    public GameObject BreatingCollider;
    public Drag dragscript;

    public GameObject Mask;

    public static bool BedUp;

    private void Awake()
    {
        BedUp = false; 
    }

    private void OnMouseDown()
    {
        if (gameObject.name == ("ClickDetectUp")) 
        {
            Bed1.SetActive(false);
            Bed2.SetActive(true);
            BreatingCollider.gameObject.transform.position = new Vector3 (-1.05299997f, 1.57700002f, -1.19099998f);
            dragscript.xCoord = 1.694f;
            BedUp = true;
        }
        else if (gameObject.name == ("ClickDetectDown"))
        {
            Bed1.SetActive(true);
            Bed2.SetActive(false);
            BreatingCollider.gameObject.transform.position = new Vector3(-1.05299997f, 1.29400003f, -1.09399998f);
            dragscript.xCoord = 1.3717f;
            BedUp = false;
        }
    }
}