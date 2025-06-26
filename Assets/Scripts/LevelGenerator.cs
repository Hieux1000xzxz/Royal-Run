using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunkCount = 10;
    [SerializeField] Transform chunkParent;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float chunkLength = 10f;
    
    List<GameObject> chunks = new List<GameObject>();

    void Start()
    {
        SpawnStartingChunks();
    }
    void Update()
    {
        MoveChunks();
    }

    private void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunkCount; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();
        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);
        chunks.Add(newChunk);
    }

    private float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;
        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }
    private void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            if (chunks[i] != null)
            {
                chunks[i].transform.Translate(- transform.forward * moveSpeed * Time.deltaTime);
                if(chunks[i].transform.position.z <= Camera.main.transform.position.z - chunkLength)
                {
                    chunks.Remove(chunk);
                    Destroy(chunk);
                    SpawnChunk();
                }
            }
        }
    }
}
