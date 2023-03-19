using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFromFailure : MonoBehaviour
{
    public delegate void SimResetFromFail();
    public static event SimResetFromFail SimResetMeds;

    public bool resetPressed;

    // Start is called before the first frame update
    void Start()
    {
        resetPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (resetPressed)
        {
            if (SimResetMeds != null)
            {
                SimResetMeds();
                resetPressed = false;
            }
        }
    }

    public void ResetFromSimFailure()
    {
        resetPressed = true;
    }
}
