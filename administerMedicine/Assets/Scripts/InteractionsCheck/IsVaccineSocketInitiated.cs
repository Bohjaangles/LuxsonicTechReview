using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IsVaccineSocketInitiated : MonoBehaviour
{
    public XRSocketInteractor Socket;
    // bool to be used by FailCheck in EventManager script
    public bool needleInVaccine;

    // bool for checking that the needle has been removed from socket, likely redundent
    public bool needleRemovedFromVaccine;

    // Start is called before the first frame update
    void Start()
    {
        needleInVaccine = false;
        needleRemovedFromVaccine = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Socket.hasSelection)
        {
            needleInVaccine = true;
        }

        if (needleInVaccine && !Socket.hasSelection)
        {
            needleRemovedFromVaccine = true;
        }
    }

    // subscribe to event manager called ResetFromFailure for restting values to simulation start
    private void OnEnable()
    {
        ResetFromFailure.SimResetMeds += resetBools;
    }

    private void OnDisable()
    {
        ResetFromFailure.SimResetMeds -= resetBools;
    }
    void resetBools()
    {
        needleInVaccine = false;
        needleRemovedFromVaccine = false;
    }
}
