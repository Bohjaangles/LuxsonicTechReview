using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulationSuccess : MonoBehaviour
{
    // check that all steps have been completed in order
    private SimFailCheck isAllStepsCompleted;

    // all the UI displays. Success for editing it and the other to ensure they are off
    public GameObject SuccessBanner;
    public GameObject WelcomeDisplay1;
    public GameObject WelcomeDisplay2;
    public GameObject WelcomeDisplay3;
    public GameObject FaillureDisplay;

    // for custom text within success ui display
    private int _NumAttempts;
    private string _successMessage;

    // Start is called before the first frame update
    void Start()
    {
        _NumAttempts = 0;
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
        GameObject newTextObj = new GameObject("successPathText");
        newTextObj.transform.SetParent(SuccessBanner.transform);
        Text myText = newTextObj.AddComponent<Text>();
        myText.text = _successMessage;
        WelcomeDisplay1.SetActive(false);
        WelcomeDisplay2.SetActive(false);
        WelcomeDisplay3.SetActive(false);
        FaillureDisplay.SetActive(false);
        _successMessage = $"You completed this simulation in {_NumAttempts} attempts";
        SuccessBanner.SetActive(true);
    }

    void incrementNumAttempts()
    {
        _NumAttempts++;
    }
}
