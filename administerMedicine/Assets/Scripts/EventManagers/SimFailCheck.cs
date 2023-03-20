using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimFailCheck : MonoBehaviour
{
    public delegate void ProperSequence();
    public static event ProperSequence FailCheck;

    public delegate void SuccessPath();
    public static event SuccessPath SuccessCheck;

    // Pulling in Bools from other scripts to check for fail conidtion
    public IsPatientSocketInitiated isPatientSocketInitiated;
    public IsVaccineSocketInitiated isVaccineSocketInitiated;
    public GlovesApplied isGlovesApplied;

    // Declaring Booleans for successpath script
    public bool glovesApplied;
    public bool needleInsertedInVaccine;
    public bool NeedleRemovedFromVaccine;
    public bool NeedleInsertedInPatient;

    // bool to ensure the fail trigger doesn't immediately retrigger on reset and float for timer
    private bool _failCheckCalledRecently;
    private float _resetTimer;

    // Start is called before the first frame update
    void Start()
    {
        glovesApplied = false;
        needleInsertedInVaccine = false;
        NeedleRemovedFromVaccine = false;
        NeedleInsertedInPatient = false;
        _failCheckCalledRecently = false;
        _resetTimer = 0.0f;
    }


    // Setting timer so that failcondition does not retrigger immediately
    private void OnEnable()
    {
        ResetFromFailure.SimResetMeds += StartResetTimer;
    }

    private void OnDisable()
    {
        ResetFromFailure.SimResetMeds -= StartResetTimer;
    }

    void StartResetTimer()
    {
        _resetTimer -= Time.deltaTime;
    }


    // Update is called once per frame
    private void Update()
    {

        if (_failCheckCalledRecently)
        {
            if(_resetTimer > 1.0)
            {
                _failCheckCalledRecently = false;
            }
        }
        // First check that failcheck hasn't jsut been called
        if (!_failCheckCalledRecently) 
        {

            // first check, to ensure gloves have been applied before anything else
            if (!isGlovesApplied.IsGlovesApplied && isVaccineSocketInitiated.needleInVaccine)
            {
                _failCheckCalledRecently = true;
                CallFailCheck();
                 
                    glovesApplied = false;
                    needleInsertedInVaccine = false;
                    NeedleRemovedFromVaccine = false;
                    NeedleInsertedInPatient = false;
                    _resetTimer = 3.0f;
                
            } else
            {
                glovesApplied = true;
            }

            // second check to ensure needle has been inserted in vaccine before It is removed and stuck into the patient.
            if (!isVaccineSocketInitiated.needleInVaccine && isPatientSocketInitiated.DoesPatientGetNeedle)
            {
                _failCheckCalledRecently = true;
                CallFailCheck();
                
                    FailCheck();
                    glovesApplied = false;
                    needleInsertedInVaccine = false;
                    NeedleRemovedFromVaccine = false;
                    NeedleInsertedInPatient = false;
                    _resetTimer = 3.0f;
                
            } else
            {
                needleInsertedInVaccine = true;
            }

            // final check that everything required of simulation has been completed for success path
            if (glovesApplied && needleInsertedInVaccine && isPatientSocketInitiated.DoesPatientGetNeedle)
            {
                NeedleInsertedInPatient = true;
                if(SuccessCheck != null)
                {
                    SuccessCheck();
                }
            }
        }
    }

    private void CallFailCheck()
    {
        if (FailCheck != null)
        {
            FailCheck();
        }
    }
}