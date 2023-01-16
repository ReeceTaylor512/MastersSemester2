using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    private FunctionTimer functionTimer;
    private void Start()
    {
       functionTimer = new FunctionTimer(OutofTime, 30f);

           

    }

    private void Update()
    {
        functionTimer.Update();
    }

    private void OutofTime()
    {

        Debug.Log("OutofTime");
    }
}
