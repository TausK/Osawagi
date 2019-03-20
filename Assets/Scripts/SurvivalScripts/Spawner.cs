using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float delay = 0.5f;
    public float timer;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
   
    public enum Spawn
    {
        NULL,
        Call1,
        Call2,
        Call3 
    }
    public Spawn SpawnType;
    public int spawnNumType = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > delay)
        {
            spawnNumType = Random.Range(1, 4);
            timer = 0f;
        }
       if (spawnNumType > 0 && spawnNumType <=3)
        {
            switch (spawnNumType)
            {
                case 1:
                    SpawnType = Spawn.Call1;
                    spawnNumType = 0;
                    break;
                case 2:
                    SpawnType = Spawn.Call2;
                    spawnNumType = 0;

                    break;
                case 3:
                    SpawnType = Spawn.Call3;
                    spawnNumType = 0;
                    break;
            }
            Debug.Log(SpawnType.ToString());

        }
        else
        {
            SpawnType = Spawn.NULL;
            spawnNumType = 0;
        }
        switch (SpawnType)
        {
                case Spawn.NULL:
                    spawner1.GetComponent<ObjectsSpawner>().spawn = 0;
                    spawner2.GetComponent<ObjectsSpawner>().spawn = 0;
                    spawner3.GetComponent<ObjectsSpawner>().spawn = 0;
                    break;
                case Spawn.Call1:
                    spawner1.GetComponent<ObjectsSpawner>().spawn = 1;
                    break;
                case Spawn.Call2:
                    spawner2.GetComponent<ObjectsSpawner>().spawn = 1;
                    break;
                case Spawn.Call3:
                    spawner3.GetComponent<ObjectsSpawner>().spawn = 1;
                    break;
        }
    }
}