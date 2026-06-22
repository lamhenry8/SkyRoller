using UnityEngine;
using System.Collections.Generic;

public class EndlessGenerator : MonoBehaviour
{
    public Transform player;
    public GameObject[] chunkPrefabs;
    public GameObject startChunkPrefab;

    public int chunksAhead = 8;
    public float despawnDistance = 50f;

    private Queue<GameObject> activeChunks = new();
    private Transform currentExit;

    void Start()
    {
        SpawnStartChunk();

        for (int i = 0; i < chunksAhead; i++)
        {
            SpawnChunk();
        }
    }

    void SpawnStartChunk()
    {
        GameObject startChunk = Instantiate(startChunkPrefab);

        ChunkData data = startChunk.GetComponent<ChunkData>();

        currentExit = data.exitPoint;

        activeChunks.Enqueue(startChunk);
    }

    void Update()
    {
        while (activeChunks.Count < chunksAhead + 1)
        {
            SpawnChunk();
        }

        RemoveOldChunks();
    }

    void SpawnChunk()
    {
        GameObject prefab =
            chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];

        GameObject chunk =
            Instantiate(prefab);

        ChunkData data =
            chunk.GetComponent<ChunkData>();

        Vector3 offset =
            currentExit.position -
            data.entryPoint.position;

        offset.y = 0;

        chunk.transform.position += offset;

        currentExit = data.exitPoint;

        activeChunks.Enqueue(chunk);
    }

    void RemoveOldChunks()
    {
        while (activeChunks.Count > 0)
        {
            GameObject oldest = activeChunks.Peek();

            if (player.position.z - oldest.transform.position.z
                > despawnDistance)
            {
                Destroy(oldest);
                activeChunks.Dequeue();
            }
            else
            {
                break;
            }
        }
    }
}