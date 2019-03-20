using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    
    public float rotationSpeed;
    // Update is called once per frame
    void Update()
    { //we put if statement

      
        {
            
            transform.Rotate(Vector3.back, rotationSpeed);

        }

    }
}
