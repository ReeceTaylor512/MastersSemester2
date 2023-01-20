using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickChecker : MonoBehaviour
{
    public GameObject Bed1;
    public GameObject Bed2;
    public GameObject BreatingCollider;
    public Drag dragscript;
    public UI TimerScript;
    public DragDrop Mask;
    public GameObject Charachter;
    public GameObject Charachter2;
    public Material newMat;
    public GameObject maskk;
    public GameObject cantspeak;
    public GameObject canspeak;

    public static bool BedUp;
    public bool Maskon = false;

    bool timeAdded = false;

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
            maskandbedCheck();
            if (timeAdded == false) 
            {
                TimerScript.timerVal = TimerScript.timerVal + 30f;
                timeAdded = true;
            }
            if (Mask.maskison) 
            {
                maskk.transform.position = new Vector3(-1.04250002f, 1.81140006f, -0.938899994f);
                maskk.transform.eulerAngles = new Vector3(0f, 270f, 34.163662f);
            }
        }
        else if (gameObject.name == ("ClickDetectDown"))
        {
            Bed1.SetActive(true);
            Bed2.SetActive(false);
            BreatingCollider.gameObject.transform.position = new Vector3(-1.05299997f, 1.29400003f, -1.09399998f);
            dragscript.xCoord = 1.3717f;
            BedUp = false;
            maskandbedCheck();
            if (Mask.maskison) 
            {
                maskk.transform.position = new Vector3(-1.04499996f, 1.30500007f, -0.694999993f);
                maskk.transform.eulerAngles = new Vector3(0f, 270f, 0f);
            }
        }        
    }
    public void maskandbedCheck()
    {
        if (BedUp == true && Mask.maskison == true) 
        {
            TimerScript.timerVal = TimerScript.timerVal + 60f;
            Charachter.GetComponent<MeshRenderer>().material = newMat;
            Charachter2.GetComponent<MeshRenderer>().material = newMat;
            cantspeak.SetActive(false);
            canspeak.SetActive(true);
            this.Wait(3f,speakdelay);
        }
    }
    void speakdelay() 
    {
        canspeak.SetActive(false);
    }
}