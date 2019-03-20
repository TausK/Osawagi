using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PvpSelect : MonoBehaviour
{
    #region Variables
    [Header("Character Select Icon & Texture Style")]
    //Texture array for character icon texture
    public Texture2D[] charIcon = new Texture2D[4];
    //public GUIStyle
    [Space(3)]

    [Header("Index Selection for players")]
    //Set index for player 1 & 2
    public int indexP1;
    public int indexP2;
    
    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        #region Character Texture Icon Reference
        //Reference textures into Texture2D arrar
        charIcon[0] = Resources.Load("Icon/GeishaIcon") as Texture2D;
        charIcon[1] = Resources.Load("Icon/OniIcon") as Texture2D;
        charIcon[2] = Resources.Load("Icon/SamuraiIcon") as Texture2D;
        charIcon[3] = Resources.Load("Icon/NinjaIcon") as Texture2D;
        #endregion
    }

    private void OnGUI()
    {
        
    }
}
