using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IsPatientSocketInitiated : MonoBehaviour
{
    public XRSocketInteractor Socket;
    // Bool to check if socket gets a needle attached to it
    public bool DoesPatientGetNeedle;
    // Start is called before the first frame update
    void Start()
    {
        DoesPatientGetNeedle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Socket.hasSelection)
        {
            DoesPatientGetNeedle = true;
        }
    }

    private void OnEnable()
    {
        ResetFromFailure.SimResetMeds += ResetBool;
    }

    private void OnDisable()
    {
        ResetFromFailure.SimResetMeds -= ResetBool;
    }
    void ResetBool()
    {
        DoesPatientGetNeedle = false;
    }
}
