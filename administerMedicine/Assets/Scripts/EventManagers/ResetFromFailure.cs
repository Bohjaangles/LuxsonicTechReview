using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFromFailure : MonoBehaviour
{
    public delegate void SimResetFromFail();
    public static event SimResetFromFail SimResetMeds;

    public void ResetFromSimFailure()
    {
            if (SimResetMeds != null)
            {
                SimResetMeds();
            }
    }
}
