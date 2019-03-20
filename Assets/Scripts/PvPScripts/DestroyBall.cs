using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "BallZone")
        {
            Destroy(gameObject);
        }
    }
}
