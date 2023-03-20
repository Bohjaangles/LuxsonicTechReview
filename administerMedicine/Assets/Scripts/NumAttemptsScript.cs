using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumAttemptsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int NumAttempts = 1;

    public void IncrementAtempts()
    {
        NumAttempts += 1;
    }
}
