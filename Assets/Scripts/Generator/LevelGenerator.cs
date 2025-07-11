using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] chunkPrefab;
    [SerializeField] GameObject checkPoint;
    [SerializeField] int startingChunkCount = 12;
    [SerializeField] int checkPointInterval = 8;
    [SerializeField] Transform chunkParent;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    [SerializeField] float maxMoveSpeed = 20f;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] CameraController cameraController;
    [SerializeField] ScoreManager scoreManager;

    List<GameObject> chunks = new List<GameObject>();
    int chunkSpawned = 0;

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

    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        float newMoveSpeed = moveSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minMoveSpeed, maxMoveSpeed);
        if (newMoveSpeed != moveSpeed)
        {
            moveSpeed = newMoveSpeed;
            float newGravityZ = Physics.gravity.z - speedAmount;
            newGravityZ = Mathf.Clamp(newGravityZ, -22f, 22f);
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);
            cameraController.ChangeCameraFOV(speedAmount);
        }
       
    }
    private void SpawnChunk()
    {

        float spawnPositionZ = CalculateSpawnPositionZ();
        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject chunkSpawn = ChooseChunkToSpawn();
        GameObject newChunkGO = Instantiate(chunkSpawn, chunkSpawnPos, Quaternion.identity, chunkParent);
        chunks.Add(newChunkGO);
        Chunk newChunk = newChunkGO.GetComponent<Chunk>();
        newChunk.Init(this, scoreManager);
        chunkSpawned++;
    }

    private GameObject ChooseChunkToSpawn()
    {
        GameObject chunkSpawn;
        if (chunkSpawned % checkPointInterval == 0 && chunkSpawned != 0)
        {
            chunkSpawn = checkPoint;
        }
        else
        {
            chunkSpawn = chunkPrefab[Random.Range(0, chunkPrefab.Length)];
        }

        return chunkSpawn;
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
