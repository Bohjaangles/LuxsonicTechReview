using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TurnOffSocket : MonoBehaviour
{
    public XRSocketInteractor socket;

    void socketOff()
    {
        socket.EndManualInteraction();
        socket.socketActive = false;
    }

    void socketOn()
    {
        socket.socketActive = true;
    }
    private void OnEnable()
    {
        SimFailCheck.FailCheck += socketOff;
        ResetFromFailure.SimResetMeds += socketOn;
    }

    private void OnDisable()
    {
        SimFailCheck.FailCheck -= socketOff;
        ResetFromFailure.SimResetMeds -= socketOn;
    }

}
