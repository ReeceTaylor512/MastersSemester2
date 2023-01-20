using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class mainmeny : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey) 
        {
            SceneManager.LoadScene("Main");
        }
    }
}
