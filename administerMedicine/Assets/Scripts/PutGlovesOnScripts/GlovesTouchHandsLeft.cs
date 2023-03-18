using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GlovesTouchHandsLeft : MonoBehaviour
{
    public bool LeftHandTouchGlove;
    private void Start()
    {
        LeftHandTouchGlove = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Glove"))
        {
            LeftHandTouchGlove = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Glove"))
        {
            LeftHandTouchGlove = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Glove"))
        {
            LeftHandTouchGlove = false;
        }
    }
}
