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

    // for custom text within success ui display
    private int _NumAttempts;
    private string _SuccessMessage;
    private bool _numAttemptsIncremented = false;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        _NumAttempts = 1;
    }

    private void Update()
    {
        if (_numAttemptsIncremented)
        {
            timer = 3.0f;
            timer -= Time.deltaTime;
            if (timer < 0.1)
            {
                _numAttemptsIncremented = false;
            }
        }
    }

    private void OnEnable()
    {
        SimFailCheck.FailCheck += incrementNumAttempts;
        SimFailCheck.SuccessCheck += SimComplete;
    }
    private void OnDisable()
    {
        SimFailCheck.FailCheck -= incrementNumAttempts;
        SimFailCheck.SuccessCheck -= SimComplete;
    }

    void SimComplete()
    {
        /*
        if (_NumAttempts > 1)
        {
            for (int i = _NumAttempts; i > 1; i--) 
            {
                _SuccessMessage += $"";
            };
        }
        */
        _SuccessMessage = $"You completed this simulation in {_NumAttempts} attempts";
        SucessText.GetComponent<TMPro.TextMeshProUGUI>().text = _SuccessMessage;
        WelcomeDisplay1.SetActive(false);
        WelcomeDisplay2.SetActive(false);
        WelcomeDisplay3.SetActive(false);
        FaillureDisplay.SetActive(false);
        SuccessBanner.SetActive(true);
    }

    void incrementNumAttempts()
    {
        _NumAttempts++;
        _numAttemptsIncremented = true;
    }
}
