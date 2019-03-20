using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // i change pause to public
    public bool pause;
    private bool showOptions;
    private bool showMenu;

    public GUIStyle pauseBackground, resume, control, exit, paused, playerControls, backButton;

    private float scrW;
    private float scrH;


    // Update is called once per frame
    void Update()
    {
        scrW = Screen.width / 16;
        scrH = Screen.height / 9;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = true;
        }
    }

    void OnGUI()
    {
        if (pause == true)
        {
            Time.timeScale = 0.0f;
            GUI.Box(new Rect(5.0f * scrW, 2.0f * scrH, 6.0f * scrW, 5.0f * scrH), "", pauseBackground); //background
            GUI.Box(new Rect(7.0f * scrW, 2.8f * scrH, 2.0f * scrW, 0.5f * scrH), "", paused); // Icon
            if (GUI.Button(new Rect(6.9f * scrW, 3.7f * scrH, 2.0f * scrW, 0.5f * scrH), "", resume))
            {
                pause = false;
                Time.timeScale = 1.0f;

            }
            if (GUI.Button(new Rect(7.0f * scrW, 4.5f * scrH, 2.0f * scrW, 0.5f * scrH), "", control))
            {
                pause = false;
                showOptions = true;
            }
            if (GUI.Button(new Rect(7.0f * scrW, 5.5f * scrH, 2.0f * scrW, 0.5f * scrH), "", exit))
            {

                SceneManager.LoadScene("MainMenuOsawagi");
            }
        }

        if (showOptions == true)
        {
            GUI.Box(new Rect(0.0f * scrW, 0.0f * scrH, 16.07f * scrW, 9.0f * scrH), "", playerControls);
            if (GUI.Button(new Rect(13.0f * scrW, 8.0f * scrH, 2.0f * scrW, 1.0f * scrH), "", backButton))
            {
                pause = true;
                showOptions = false;
            }
        }

    }
}
