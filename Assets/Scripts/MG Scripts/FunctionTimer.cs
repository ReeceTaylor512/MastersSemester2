using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTimer : MonoBehaviour
{

    private Action action;
   private float timer;

    public FunctionTimer(Action action, float timer)
    {

        this.action = action;
        this.timer = timer;
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer <0)
        {
            // Trigger player failed.
            action();
        }
    }
}
