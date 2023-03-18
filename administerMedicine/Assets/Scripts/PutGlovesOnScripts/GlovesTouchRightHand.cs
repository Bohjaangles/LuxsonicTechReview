using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovesTouchRightHand : MonoBehaviour
{
    public bool RightHandTouchGlove;
    private void Start()
    {
        RightHandTouchGlove = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Glove"))
        {
            RightHandTouchGlove = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Glove"))
        {
            RightHandTouchGlove = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Glove"))
        {
            RightHandTouchGlove = false;
        }
    }
}
