using UnityEngine;
using System.Collections.Generic;

public class RandomBlockGenerator : MonoBehaviour
{
    public GameObject[] blockPrefabs; // Array de prefabs de bloques
    public int[] maxBlockCounts; // Array de máximas cantidades de cada bloque

    public int totalBlockCount = 200; // Máxima cantidad de bloques en total

    // Límites de las coordenadas
    private float xMin = -8.77917f;
    private float xMax = 8.779175f;
    private float zMin = -12.5f;
    private float zMax = 12.5f;
    private float y = 1f;

    private HashSet<Vector3> occupiedPositions = new HashSet<Vector3>();

    void Start()
    {
        GenerateBlocks();
    }

    void GenerateBlocks()
    {
        int blocksPlaced = 0;
        int[] currentBlockCounts = new int[blockPrefabs.Length];

        while (blocksPlaced < totalBlockCount)
        {
            int prefabIndex = Random.Range(0, blockPrefabs.Length);

            if (currentBlockCounts[prefabIndex] < maxBlockCounts[prefabIndex])
            {
                Vector3 randomPosition = GetRandomPosition();
                while (occupiedPositions.Contains(randomPosition))
                {
                    randomPosition = GetRandomPosition();
                }

                occupiedPositions.Add(randomPosition);
                Instantiate(blockPrefabs[prefabIndex], randomPosition, Quaternion.identity);
                currentBlockCounts[prefabIndex]++;
                blocksPlaced++;
            }
        }
    }

    Vector3 GetRandomPosition()
    {
        float xPos = Mathf.Floor(Random.Range(xMin, xMax + 1)); // Añadido +1 para incluir xMax
        float zPos = Mathf.Floor(Random.Range(zMin, zMax + 1)); // Añadido +1 para incluir zMax
        return new Vector3(xPos, y, zPos);
    }
}
