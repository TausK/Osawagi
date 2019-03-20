using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer;
    private float scoreTimer = 0f;
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Time.timeSinceLevelLoad >= 56)
        {
            SceneManager.LoadScene("Surv_Win");
        }

        if (timerText != null)
        {
            timerText.text = timer.ToString() + "";
        }
    }
}
