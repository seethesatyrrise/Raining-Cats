using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPositions;

    float spawnDistance = 5;

    int minAmount = 5;
    int maxAmount = 9;

    public void SpawnItems(GameObject prefab)
    {
        int amount = Random.Range(minAmount, maxAmount);
        for (int i = 0; i < amount; i++)
        {
            Transform parent = spawnPositions[Random.Range(0, spawnPositions.Length)];
            Vector3 position = RandomizePosition(parent.position);
            Quaternion rotation = Random.rotation;

            Instantiate(prefab, position, rotation, parent);
        }
    }

    Vector3 RandomizePosition(Vector3 parentPosition)
    {
        float x = RandomizeDistance() + parentPosition.x;
        float z = RandomizeDistance() + parentPosition.z;
        float y = parentPosition.y;

        return new Vector3(x, y, z);
    }

    float RandomizeDistance()
    {
        return Random.Range(-spawnDistance, spawnDistance);
    }

}
