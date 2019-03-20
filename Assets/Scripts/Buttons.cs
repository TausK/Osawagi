using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject stuffs;

    public void onStart()
    {
        SceneManager.LoadScene("SurvivalMode_01");
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnStuffs()
    {
        stuffs.SetActive(true);
    }

    public void OnBack()
    {
        stuffs.SetActive(false);
    }
}
