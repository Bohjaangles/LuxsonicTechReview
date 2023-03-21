using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulationSuccess : MonoBehaviour
{
    // all the UI displays. Success for editing it and the other to ensure they are off
    public GameObject SuccessBanner;
    public GameObject WelcomeDisplay1;
    public GameObject WelcomeDisplay2;
    public GameObject WelcomeDisplay3;
    public GameObject FaillureDisplay;
    public GameObject SucessText;
    public GameObject numAttemptsGO;

    // for custom text within success ui display
    private int _NumAttempts;

    // Start is called before the first frame update
    

    private void Update()
    {
        _NumAttempts = numAttemptsGO.GetComponent<NumAttemptsScript>().NumAttempts;
    }
    
    

    private void OnEnable()
    {
        SimFailCheck.SuccessCheck += SimComplete;
    }
    private void OnDisable()
    {
        SimFailCheck.SuccessCheck -= SimComplete;
    }

    void SimComplete()
    {
        SucessText.GetComponent<TMPro.TextMeshProUGUI>().text = $"You successfully completed this simulation in {_NumAttempts} attempt(s)";
        WelcomeDisplay1.SetActive(false);
        WelcomeDisplay2.SetActive(false);
        WelcomeDisplay3.SetActive(false);
        FaillureDisplay.SetActive(false);
        SuccessBanner.SetActive(true);
    }
}
