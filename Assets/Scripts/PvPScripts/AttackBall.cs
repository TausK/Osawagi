using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBall : MonoBehaviour
{
    public string hitColor = "";
    public int score = 0;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        //If the player collides with the coloured ball gameobject
        if (col.tag == hitColor)
        {
            //Destroy gameobject
            Destroy(col.gameObject);
            //And count the amount we destroy
            score = score + 1;
        }
    }
}
