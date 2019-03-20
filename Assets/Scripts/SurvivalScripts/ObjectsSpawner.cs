using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    public GameObject[] Platforms;
    public float spawnRadius = 20f;
    public int spawn = 0;
    public GameObject handler;

    void Update ()
    {
            SpawnCall(spawn);
    }
    void SpawnCall(int spawn)
    {
        if (spawn != 0)
        {
            Vector3 rand = Random.onUnitSphere * spawnRadius;
            rand.z = 0;
            Vector3 position = transform.position + rand;
            int randomIndex = Random.Range(0, Platforms.Length);
            GameObject clone = Instantiate(Platforms[randomIndex]);
            clone.transform.position = position;
            handler.GetComponent<Spawner>().spawnNumType = 0;
            spawn = 0;
        }
    }
}
