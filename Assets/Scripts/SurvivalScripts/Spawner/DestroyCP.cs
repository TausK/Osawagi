using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCP : MonoBehaviour
{
    public float cloneDestroy = 3.0f;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, cloneDestroy);
        Debug.Log("Clone Destroyed");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Platform")
        {
            Destroy(col.gameObject);
            Debug.Log("Ball Destroyed Platform");
        }
    }

}
