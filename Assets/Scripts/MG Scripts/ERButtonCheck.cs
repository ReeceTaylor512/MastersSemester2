using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERButtonCheck : MonoBehaviour
{
    public GameObject Questions;
    public GameObject topbar;
    public AudioSource buttonpress;
    public Canvas ER_canvas;
    public UI_Script UITimer;
    
    private void OnMouseDown()
    {
        if (gameObject.name == ("button"))
        {
            Time.timeScale = 0;
            topbar.SetActive(false);
            buttonpress.Play();
            ER_canvas.enabled = true;
            UITimer.ticking = false;
        }
    }
    public void CancelDoc() 
    {
        ER_canvas.enabled = false;
        Time.timeScale = 1;
        topbar.SetActive(true);
        UITimer.ticking = true;
        UITimer.TimerTick();
    }
}
