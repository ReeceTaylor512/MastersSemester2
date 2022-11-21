using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class Testing : MonoBehaviour
{
    private Grid grid; 
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(4, 2, 10f, new Vector3(20,0));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPositionWithZ(), 56);

        }
    }
}
