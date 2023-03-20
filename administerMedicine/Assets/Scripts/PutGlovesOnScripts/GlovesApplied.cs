using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovesApplied : MonoBehaviour
{
    public GameObject gloves;
    public GameObject leftHand;
    public GameObject rightHand;
    public Material handMaterial;
    public bool IsGlovesApplied;

    private void Start()
    {
        IsGlovesApplied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (leftHand.GetComponent<GlovesTouchHandsLeft>().LeftHandTouchGlove == true && rightHand.GetComponent<GlovesTouchRightHand>().RightHandTouchGlove == true)
        {
            IsGlovesApplied = true;
            handMaterial.color = Color.blue;
            gloves.SetActive(false);
        }
    }

    private void OnEnable()
    {
        ResetFromFailure.SimResetMeds += ResetGloves;
    }

    private void OnDisable()
    {
        ResetFromFailure.SimResetMeds -= ResetGloves;
    }
    void ResetGloves()
    {
        IsGlovesApplied = false;
        handMaterial.color = Color.white;
    }
}
