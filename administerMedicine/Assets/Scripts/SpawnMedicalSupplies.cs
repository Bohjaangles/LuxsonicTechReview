using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMedicalSupplies : MonoBehaviour
{
    public Vector3 position1;
    public Vector3 position2;
    public Vector3 position3;

    public Transform needle;
    public Transform vaccine;
    public Transform gloves;
    // Start is called before the first frame update
    void Start()
    {
        // Math.random equivelent for variables: needle, vaccine, and gloves and somehow attach that random number to these vars
        // put these vars into an array and then sort that array by the random value
        // assign the index 0 var position 1, assign index 1 var position 2, etc.  
    }

    // to be called when simulation failure condition is met
    private void Reset() {
        // Math.random equivelent for variables: needle, vaccine, and gloves and somehow attach that random number to these vars
        // put these vars into an array and then sort that array by the random value
        // assign the index 0 var position 1, assign index 1 var position 2, etc.
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
