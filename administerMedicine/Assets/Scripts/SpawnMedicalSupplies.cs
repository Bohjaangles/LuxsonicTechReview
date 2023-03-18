using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMedicalSupplies : MonoBehaviour
{
    // the positions where the medical supplies should spawn from
    public Vector3 position1;
    public Vector3 position2;
    public Vector3 position3;

    // for the container gameobject of each med supplies gameobject and their socket point
    [Header("NeedleContainer")]
    public GameObject needle;

    [Header("VaccineContainer")]
    public GameObject vaccine;

    [Header("GlovesContainer")]
    public GameObject gloves;

    private float needleValue;
    private float vaccineValue;
    private float glovesValue;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // to be called when simulation failure condition is met
    private void Reset() {
        // assign a random value to each med supplies item for random order spawning
        needleValue = Random.Range(0.0f, 10.0f);
        vaccineValue = Random.Range(0.0f, 10.0f);
        glovesValue = Random.Range(0.0f, 10.0f);

        // Ensure that all medical supplies game objects and children are set to active - 
        foreach (Transform child in gloves.transform)
        {
            child.gameObject.SetActive(true);
        }
        gloves.SetActive(true);

        foreach (Transform child in needle.transform)
        {
            child.gameObject.SetActive(true);
        }
        needle.SetActive(true);

        foreach (Transform child in vaccine.transform)
        {
            child.gameObject.SetActive(true);
        }
        vaccine.SetActive(true);

        // determine which med supplies item spawns at position 1. 
        if (needleValue < vaccineValue && needleValue < glovesValue)
        {
            needle.transform.position = position1;
        }
        if (glovesValue < vaccineValue && glovesValue < needleValue)
        {
            gloves.transform.position = position1;
        }
        if (vaccineValue < needleValue && vaccineValue < glovesValue)
        {
            vaccine.transform.position = position1;
        }

        // determine which med supplies item spawns at position 2.
        if ((needleValue < vaccineValue && needleValue > glovesValue) | (needleValue > vaccineValue && needleValue < glovesValue))
        {
            needle.transform.position = position2;
        }
        if ((glovesValue < vaccineValue && glovesValue > needleValue) | (glovesValue > vaccineValue && glovesValue < needleValue))
        {
            gloves.transform.position = position2;
        }
        if ((vaccineValue < needleValue && vaccineValue > glovesValue) | (vaccineValue > needleValue && vaccineValue < glovesValue))
        {
            vaccine.transform.position = position2;
        }

        // determine which med supplies item spawns at position 3.
        if (needleValue > vaccineValue && needleValue > glovesValue)
        {
            needle.transform.position = position3;
        }
        if (glovesValue > vaccineValue && glovesValue > needleValue)
        {
            gloves.transform.position = position3;
        }
        if (vaccineValue > needleValue && vaccineValue > glovesValue)
        {
            vaccine.transform.position = position3;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
