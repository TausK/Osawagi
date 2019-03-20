using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Make a copy of position
        Vector3 position = transform.position;
        // Modify parts of the copy (i.e, just X, not Y)
        position.x = player.transform.position.x + offset.x;
        // Apply copy to position
        transform.position = position;
    }
}
