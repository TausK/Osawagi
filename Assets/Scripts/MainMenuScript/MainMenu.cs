using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Public gameobject array of gui menus
    public GameObject[] guiMenus = new GameObject[2];

  
  
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        //set main menu false
        guiMenus[0].SetActive(false);
        //set controls menu true
        guiMenus[1].SetActive(true);
    }

    public void Back()
    {
        //set main menu true
        guiMenus[0].SetActive(true);
        //set controls menu false
        guiMenus[1].SetActive(false);
    }

   
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

 
  
}
