using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovesApplied : MonoBehaviour
{
    public GameObject gloves;
    public GameObject leftHand;
    public GameObject rightHand;
    public Material handMaterial;

    // Update is called once per frame
    void Update()
    {
        if (leftHand.GetComponent<GlovesTouchHandsLeft>().LeftHandTouchGlove == true && rightHand.GetComponent<GlovesTouchRightHand>().RightHandTouchGlove == true)
        {
            handMaterial.color = Color.blue;
            gloves.SetActive(false);
        }
    }
}
