using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner02 : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] inkBalls;

    public float spawnTimer = 3.0f;
    public float startGameTimer = 1.5f;


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", startGameTimer, spawnTimer);
    }
    void Spawn()
    {
        int objectIndex = Random.Range(0, inkBalls.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(inkBalls[objectIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);

    }
}
