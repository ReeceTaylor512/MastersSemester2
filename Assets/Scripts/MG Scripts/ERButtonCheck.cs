using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERButtonCheck : MonoBehaviour
{
    public GameObject Questions;
    public GameObject topbar;
    public AudioSource buttonpress;
    
    private void OnMouseDown()
    {
        if (gameObject.name == ("button"))
        {
            Time.timeScale = 0;
            Questions.SetActive(true);
            topbar.SetActive(false);
            buttonpress.Play();            
        }
    }
}
