using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimulationFailure : MonoBehaviour
{

    public GameObject failureUI;

    private void OnEnable()
    {
        SimFailCheck.FailCheck += SimFailure;
    }

    private void OnDisable()
    {
        SimFailCheck.FailCheck -= SimFailure;
    }

    void SimFailure()
    {
        failureUI.SetActive(true);
    }
}
