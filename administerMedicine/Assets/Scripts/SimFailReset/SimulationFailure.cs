using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimulationFailure : MonoBehaviour
{
    /// <summary>
    /// Subscribe to event manager,
    /// when the conditions for simulation failure are met, 1. set inactive all of the medical supplies.
    /// then 2. Set active the simulation failure ui gameobject
    /// </summary>

    public GameObject patient;
    public GameObject gloves;
    public GameObject needle;
    public GameObject vaccine;
    public GameObject failureUI;
   

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    { 
     
    }

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
        /*
        foreach (Transform child in gloves.transform)
        {
            child.gameObject.SetActive(false);
        }       

        foreach (Transform child in needle.transform)
        {
            child.gameObject.SetActive(false);
        }       

        foreach (Transform child in vaccine.transform)
        {
            child.gameObject.SetActive(false);
        }

        foreach (Transform child in patient.transform)
        {
            child.gameObject.SetActive(false);
        }
        */
        failureUI.SetActive(true);
    }
}
