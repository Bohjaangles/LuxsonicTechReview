using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsWhiteOnReset : MonoBehaviour
{
    public Material handMaterial;

    // Start is called before the first frame update
    void Start()
    {
        handMaterial.color = Color.white;
    }

    void ResetToWhite()
    {
        handMaterial.color = Color.white;
    }

    private void OnEnable()
    {
        ResetFromFailure.SimResetMeds += ResetToWhite;
    }

    private void OnDisable()
    {
        ResetFromFailure.SimResetMeds -= ResetToWhite;
    }

}
