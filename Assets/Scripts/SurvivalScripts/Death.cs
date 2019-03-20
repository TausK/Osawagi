using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("KillZone"))
        {
            SceneManager.LoadScene("SurvDeath");
        }
    }
}
