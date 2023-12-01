using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;

    public float frequency;

    public float initialSpeed;

    float lastSpawnedTime;

    private bool isGameActive = true;

    void Update()
    {
        if (Time.time > lastSpawnedTime + frequency)
        {
            spawnObjects();
            lastSpawnedTime = Time.time;
        }
    }

    public void spawnObjects()
    {
        int randomTile = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        float screenZ = 50f;
        Vector3 pos;

        for (int i = 0; i < numberToSpawn; i++)
        {
            randomTile = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomTile];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector3(screenX, screenY, screenZ);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
    public void SetGameActive(bool isActive)
    {
        isGameActive = isActive;
    }
}

