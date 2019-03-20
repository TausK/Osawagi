using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadPoint : MonoBehaviour
{
    public Text PersonalScore;
    private float score;

    public string triggerTag = "Head";

    void Start()
    {
        PersonalScore.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        PersonalScore.text = "" + score;
    }

    void OnTriggerStay(Collider other) // when the person jumps onto somebody else's head, they gain score
    {
        if (other.tag == "Head")
        {
            score = score + 1 * Time.deltaTime;
        }

    }

}




