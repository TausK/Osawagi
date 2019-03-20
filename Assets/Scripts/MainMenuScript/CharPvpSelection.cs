using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharPvpSelection : MonoBehaviour
{
    public KeyBindings keyBindings;

    private bool playSelect;
    private bool chooseMode;
    private bool survival;
    private float scrW;
    private float scrH;

    public GUIStyle geisha, oni, samurai, ninja, oneVOne, back, start, reselect, firstPlayer, secondPlayer, chooseCharTitle, survivalStyle;

    public string[] selectChars = new string[2];
    // public string[] playerScore = new string[2];

    [Header("Char Select Icon Shit")]
    public Texture2D[] charIcon = new Texture2D[4];
    public int indexP1;
    public int indexP2;

    void Start()
    {
        charIcon[0] = Resources.Load("Icons/GeishaIcon") as Texture2D;
        charIcon[1] = Resources.Load("Icons/OniIcon") as Texture2D;
        charIcon[2] = Resources.Load("Icons/SamuraiIcon") as Texture2D;
        charIcon[3] = Resources.Load("Icons/NinjaIcon") as Texture2D;

        chooseMode = true;
        selectChars[0] = "";
        selectChars[1] = "";
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
        if (chooseMode)
        {

            if (GUI.Button(new Rect(5.0f * scrW, 2.0f * scrH, 5.0f * scrW, 3.0f * scrH), "", oneVOne))
            {
                chooseMode = false;
                playSelect = true;
            }
            if (GUI.Button(new Rect(6.5f * scrW, 7.8f * scrH, 2.0f * scrW, 1.0f * scrH), "", back))
            {
                chooseMode = false;
                SceneManager.LoadScene("MainMenuOsawagi");
            }
            if(GUI.Button(new Rect(5.0f * scrW, 4.0f * scrH, 5.0f * scrW, 3.0f * scrH), "", survivalStyle))
            {
                chooseMode = false;
                SceneManager.LoadScene("SurvivalMode");
            }
        }
        if (playSelect == true)
        {
            GUI.Box(new Rect(5.0f * scrW, 4.0f * scrH, 2.0f * scrW, 0.5f * scrH), "Geisha", chooseCharTitle);
            GUI.Box(new Rect(8.0f * scrW, 4.0f * scrH, 2.0f * scrW, 0.5f * scrH), "Oni", chooseCharTitle);
            GUI.Box(new Rect(5.0f * scrW, 6.5f * scrH, 2.0f * scrW, 0.5f * scrH), "Samurai", chooseCharTitle);
            GUI.Box(new Rect(8.0f * scrW, 6.5f * scrH, 2.0f * scrW, 0.5f * scrH), "Ninja", chooseCharTitle);

            GUI.Box(new Rect(5.0f * scrW, 0.5f * scrH, 5.0f * scrW, 1.0f * scrH), "Choose 2 Characters!", chooseCharTitle);
            GUI.Box(new Rect(1.0f * scrW, 0.5f * scrH, 3.0f * scrW, 1.5f * scrH), "\n" + selectChars[0], firstPlayer);
            if (selectChars[0] != "")
            {
                if (GUI.Button(new Rect(1.0f * scrW, 4.5f * scrH, 3.0f * scrW, 1.2f * scrH), "", reselect))
                {
                    selectChars[0] = "";
                }
                GUI.DrawTexture(new Rect(1.0f * scrW, 1.7f * scrH, 3.0f * scrW, 3.0f * scrH), charIcon[indexP1]);
            }
            GUI.Box(new Rect(11.0f * scrW, 0.5f * scrH, 3.0f * scrW, 1.5f * scrH), "\n" + selectChars[1], secondPlayer);
            if (selectChars[1] != "")
            {
                if (GUI.Button(new Rect(11.0f * scrW, 4.5f * scrH, 3f * scrW, 1.2f * scrH), "", reselect))
                {
                    selectChars[1] = "";
                }
                GUI.DrawTexture(new Rect(11.0f * scrW, 1.7f * scrH, 3.0f * scrW, 3.0f * scrH), charIcon[indexP2]);

            }

            //If geisha button is pressed then....

            if (GUI.Button(new Rect(5.0f * scrW, 2.0f * scrH, 2.0f * scrW, 2.0f * scrH), "", geisha))
            {
                //If geisha isnt selected as player 1 but player 2 then....
                if (selectChars[0] != "" && selectChars[1] == "")

                {
                    //Set geisha as player 2
                    selectChars[1] = "Geisha";
                    indexP2 = 0;
                }
                //Otherwise if geisha is player 1
                if (selectChars[0] == "")
                {
                    //Then geisha is player 1
                    selectChars[0] = "Geisha";
                    indexP1 = 0;
                }

            }
            if (GUI.Button(new Rect(8.0f * scrW, 2.0f * scrH, 2.0f * scrW, 2.0f * scrH), "", oni))
            {
                if (selectChars[0] != "" && selectChars[1] == "")
                {
                    selectChars[1] = "Oni";
                    indexP2 = 1;
                }
                if (selectChars[0] == "")
                {
                    selectChars[0] = "Oni";
                    indexP1 = 1;
                }

            }
            if (GUI.Button(new Rect(5.0f * scrW, 4.5f * scrH, 2.0f * scrW, 2.0f * scrH), "", samurai))
            {
                if (selectChars[0] != "" && selectChars[1] == "")
                {
                    selectChars[1] = "Samurai";
                    indexP2 = 2;
                }
                if (selectChars[0] == "")
                {
                    selectChars[0] = "Samurai";
                    indexP1 = 2;
                }

            }
            if (GUI.Button(new Rect(8.0f * scrW, 4.5f * scrH, 2.0f * scrW, 2.0f * scrH), "", ninja))
            {
                if (selectChars[0] != "" && selectChars[1] == "")
                {
                    selectChars[1] = "Ninja";
                    indexP2 = 3;
                }
                if (selectChars[0] == "")
                {
                    selectChars[0] = "Ninja";
                    indexP1 = 3;
                }

            }

            //If the slots are are not empty then...
            if (selectChars[0] != "" && selectChars[1] != "")
            {
                //Once the start button appears then....
                if (GUI.Button(new Rect(6.3f * scrW, 7.0f * scrH, 2.5f * scrW, 1.3f * scrH), "", start))
                {
                    //Load chosen strings as gameobjects
                    PlayerPrefs.SetString("Player1", selectChars[0]);
                    PlayerPrefs.SetString("Player2", selectChars[1]);
                    SceneManager.LoadScene("PvP_01");
                    Time.timeScale = 1.0f;
                }
            }

            if (GUI.Button(new Rect(6.5f * scrW, 8.1f * scrH, 2.0f * scrW, 1.0f * scrH), "", back))
            {
                selectChars[0] = "";
                selectChars[1] = "";
                playSelect = false;
                chooseMode = true;
            }
        }
    }
}
