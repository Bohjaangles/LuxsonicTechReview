using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureReset : MonoBehaviour
{
    /// <summary>
    /// Subscribe to event manager,
    /// when the conditions for simulation failure are met, 1. set inactive all of the medical supplies.
    /// then 2. Set active the simulation failure ui gameobject
    /// </summary>


    public GameObject gloves;
    public GameObject needle;
    public GameObject vaccine;
    public GameObject failureUI;
    private bool _failCondition;
    private float timer = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        _failCondition = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 1.0)
        {
            _failCondition = true;
        }

        if(_failCondition)
        {
            foreach(Transform child in gloves.transform)
            {
                child.gameObject.SetActive(false);
            }
            gloves.SetActive(false);

            foreach (Transform child in needle.transform)
            {
                child.gameObject.SetActive(false);
            }
            needle.SetActive(false);

            foreach (Transform child in vaccine.transform)
            {
                child.gameObject.SetActive(false);
            }
            vaccine.SetActive(false);

            failureUI.SetActive(true);
        }
    }
}
