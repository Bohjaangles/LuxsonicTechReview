using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimFailCheck : MonoBehaviour
{
    public delegate void ProperSequence();
    public static event ProperSequence FailCheck;

    // Pulling in Bools from other scripts to check for fail conidtion
    public IsPatientSocketInitiated isPatientSocketInitiated;
    public IsVaccineSocketInitiated isVaccineSocketInitiated;
    public GlovesApplied isGlovesApplied;

    // Declaring Booleans for successpath script
    public bool glovesApplied;
    public bool needleInsertedInVaccine;
    public bool NeedleRemovedFromVaccine;
    public bool NeedleInsertedInPatient;

    // Start is called before the first frame update
    void Start()
    {
        glovesApplied = false;
        needleInsertedInVaccine = false;
        NeedleRemovedFromVaccine = false;
        NeedleInsertedInPatient = false;
    }

    // Update is called once per frame
    void Update()
    {
        // first check, to ensure gloves have been applied before anything else
        if (!isGlovesApplied.IsGlovesApplied && isVaccineSocketInitiated.needleInVaccine)
        {
            if (FailCheck != null)
            {
                FailCheck();
                glovesApplied = false;
                needleInsertedInVaccine = false;
                NeedleRemovedFromVaccine = false;
                NeedleInsertedInPatient = false;
            }
        } else
        {
            glovesApplied = true;
        }
        
        // second check to ensure needle has been inserted in vaccine before it is removed. This step may be redundent but including it anyways.
        if(!isVaccineSocketInitiated.needleInVaccine && isVaccineSocketInitiated.needleRemovedFromVaccine)
        {
            if(FailCheck != null)
            {
                FailCheck();
                glovesApplied = false;
                needleInsertedInVaccine = false;
                NeedleRemovedFromVaccine = false;
                NeedleInsertedInPatient = false;
            }
        } else
        {
            needleInsertedInVaccine = true;
        }

        // third check to ensure needle is removed from vaccine prior to sticking the needle in patients deltoid
        if(!isVaccineSocketInitiated.needleRemovedFromVaccine && isPatientSocketInitiated.DoesPatientGetNeedle)
        {
            if(FailCheck != null)
            {
                FailCheck();
                glovesApplied = false;
                needleInsertedInVaccine = false;
                NeedleRemovedFromVaccine = false;
                NeedleInsertedInPatient = false;
            }
        } else
        {
            NeedleRemovedFromVaccine = true;
        }

        // final check that everything required of simulation has been completed for success path
        if (glovesApplied && needleInsertedInVaccine && NeedleRemovedFromVaccine && isPatientSocketInitiated.DoesPatientGetNeedle)
        {
            NeedleInsertedInPatient = true;
        }
    }
}