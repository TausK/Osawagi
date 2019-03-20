using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivalScripts
{


    public class CharacterSpawn : MonoBehaviour
    {
        public GameObject player;
        // Use this for initialization
        void Awake()
        {
            player = Resources.Load("Character_Suvival/" + PlayerPrefs.GetString("Player1")) as GameObject;
        }

        // Update is called once per frame
        void Start()
        {
            Instantiate(player, this.transform.position, Quaternion.identity);
        }
    }
}
