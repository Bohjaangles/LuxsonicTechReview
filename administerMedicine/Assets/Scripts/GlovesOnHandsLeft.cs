using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovesOnHandsLeft : MonoBehaviour
{
    public Transform hand; // maybe MeshTransform
    public Transform glove;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // if glove material interacts with other hand material(the hand that isnt holding it)
        // destroy glove / turn the glove object off, change the hand matriel to be blue 
    }
}
