using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private void Start()
    {
        new FunctionTimer(OutofTime,30f );

           

    }

    private void OutofTime()
    {

        Debug.Log("OutofTime");
    }
}
