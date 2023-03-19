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
        ResetFromFailure.SimResetMeds += resetGloves;
    }

    private void OnDisable()
    {
        ResetFromFailure.SimResetMeds -= resetGloves;
    }
    void resetGloves()
    {
        IsGlovesApplied = false;
        handMaterial.color = Color.white;
    }
}
