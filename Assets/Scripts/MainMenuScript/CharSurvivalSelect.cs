using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class CharSurvivalSelect : MonoBehaviour
{
    private bool playSelect;
    private float scrW;
    private float scrH;
    
    private string[] selectChars = new string[1];


    void Start()
    {
        playSelect = true;
        selectChars[0] = "";

    }

    void Update()
    {
        if (Screen.width / 16 != scrW || Screen.height / 9 != scrH)
        {
            scrW = Screen.width / 16;
            scrH = Screen.height / 9;
        }
    }
    void OnGUI()
    {
        if (playSelect)
        {
            GUI.Box(new Rect(0.0f * scrW, 0.0f * scrH, 16.07f * scrW, 9.0f * scrH), "");
            GUI.Box(new Rect(5.0f * scrW, 0.5f * scrH, 5.0f * scrW, 1.0f * scrH), "Choose a Characters!");
            GUI.Box(new Rect(1.0f * scrW, 0.5f * scrH, 3.0f * scrW, 1.0f * scrH), "Player 1:\n" + selectChars[0]);
            if (selectChars[0] != "")
            {
                if (GUI.Button(new Rect(1.0f * scrW, 1.5f * scrH, 3f * scrW, 0.5f * scrH), "Reselect"))
                {
                    selectChars[0] = "";
                }
            }

            if (GUI.Button(new Rect(5.0f * scrW, 2.0f * scrH, 2.0f * scrW, 1.5f * scrH), "Geisha Icon"))
            {
                if (selectChars[0] == "")
                {
                    selectChars[0] = "Geisha";
                }


            }
            if (GUI.Button(new Rect(8.0f * scrW, 2.0f * scrH, 2.0f * scrW, 1.5f * scrH), "Oni Icon"))
            {
                if (selectChars[0] == "")
                {
                    selectChars[0] = "Oni";
                }


            }
            if (GUI.Button(new Rect(5.0f * scrW, 4.5f * scrH, 2.0f * scrW, 1.5f * scrH), "Samurai Icon"))
            {
                if (selectChars[0] == "")
                {
                    selectChars[0] = "Samurai";
                }
            }
            if (GUI.Button(new Rect(8.0f * scrW, 4.5f * scrH, 2.0f * scrW, 1.5f * scrH), "Ninja Icon"))
            {
                if (selectChars[0] == "")
                {
                    selectChars[0] = "Ninja";
                }
            }

            if (selectChars[0] != "")
            {
                if (GUI.Button(new Rect(6.3f * scrW, 6.5f * scrH, 2.5f * scrW, 1.0f * scrH), "Start Game!"))
                {
                    PlayerPrefs.SetString("Player1", selectChars[0]);
                    SceneManager.LoadScene("SurvivalMode");
                    Time.timeScale = 1.0f;
                    
                }
            }

            if (GUI.Button(new Rect(14.0f * scrW, 8.4f * scrH, 2.0f * scrW, 0.5f * scrH), "Back"))
            {
                selectChars[0] = "";
                playSelect = false;
                SceneManager.LoadScene("MainMenuOsawagi");
            }
        }
    }
}


