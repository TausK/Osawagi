using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PvPScripts
{
    public class CharacterSpawn : MonoBehaviour
    {
        public GameObject player1;
        public GameObject player2;
        public Transform playerSpawn1;
        public Transform playerSpawn2;

    
        

        // Use this for initialization
        void Awake()
        {
            player1 = Resources.Load("Character_PvP/" + PlayerPrefs.GetString("Player1")) as GameObject;
            player2 = Resources.Load("Character_PvP/" + PlayerPrefs.GetString("Player2")) as GameObject;
            Instantiate(player1, playerSpawn1.position, Quaternion.identity);
            Instantiate(player2, playerSpawn2.position, Quaternion.identity);
        }
    }
}
