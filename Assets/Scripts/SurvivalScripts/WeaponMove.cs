using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour
 {
    #region
    public float rotationSpeed;
    public float maxAngle = 45f;
    public float minAngle = -45f;
    private float angle = 0f;
    #endregion
    // Update is called once per frame
    void Update()
    {
        WeaponRotate();
    }

    void WeaponRotate()
    {
        if (Input.GetKey(KeyCode.I) && angle < maxAngle)
        {
            angle += rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.J) && angle > minAngle)
        {
            angle -= rotationSpeed * Time.deltaTime;
        }
        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
