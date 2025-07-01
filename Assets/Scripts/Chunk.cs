using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;

    [SerializeField] float appleSpawnChance = 0.3f;
    [SerializeField] float coinSpawnChance = 0.5f;
    [SerializeField] float coinSeparation = 2f;
    [SerializeField] float[] lanes = {-2.5f, 0f, 2.5f };
    private List<int> availableLanes = new List<int> { 0, 1, 2 };

    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }
    void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, 3);
        for(int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0)
            {
                break;
            }
            int laneIndex = SelectLane();
            Vector3 spawnPosition = new Vector3(lanes[laneIndex], transform.position.y + 0.4f, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, transform);
        }

    }

    private int SelectLane()
    {
        int randomIndex = Random.Range(0, availableLanes.Count);
        int laneIndex = availableLanes[randomIndex];
        availableLanes.RemoveAt(randomIndex);
        return laneIndex;
    }

    void SpawnApple()
    {
        if (Random.value > appleSpawnChance || availableLanes.Count <= 0)
        {
            return;
        }   
       
        int laneIndex = SelectLane();
        Vector3 spawnPosition = new Vector3(lanes[laneIndex], transform.position.y + 0.4f, transform.position.z);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity, transform);
    }
    void SpawnCoins()
    {
        if (Random.value > coinSpawnChance || availableLanes.Count <= 0)
        {
            return;
        }
        int selectIndex = SelectLane();

        int maxCoinsToSpawn = 5;
        int coinsToSpawn = Random.Range(1, maxCoinsToSpawn + 1);
        float topOfChunkZPos = transform.position.z + coinSeparation * 2f;

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnZ = topOfChunkZPos - (i * coinSeparation);
            Vector3 spawnPosition = new Vector3(lanes[selectIndex], transform.position.y + 0.4f, spawnZ);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, transform);
        }

    }
}
