using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WallDeath : MonoBehaviour
{
    public float wallTimer = 0f;
    public float playerDeath = 5.0f;
    public bool runTimer;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            runTimer = true;
        }

    }
    void Update()
    {
        if (runTimer)
        {
            wallTimer += Time.deltaTime;
            if (wallTimer >= playerDeath)
            {
                SceneManager.LoadScene("SurvDeath");
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            wallTimer = 0f;
            runTimer = false;
        }
    }
}