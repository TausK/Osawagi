using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    public UnityEvent death;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name.Contains("KillZone"))
        {
            death.Invoke();
        }
    }
}
