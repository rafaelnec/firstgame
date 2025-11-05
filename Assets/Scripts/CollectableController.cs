using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{

    [SerializeField] private GameObject collectablePrefab;

    [SerializeField] private Transform parentTransform;

    public float minSpawnY = 0f; // Minimum Y position for spawning
    public float maxSpawnY = -2.43f; // Maximum Y position for spawning
    public float minOffsetX = -27f;
    public float maxOffsetX = 30f;
    public float minpaddingX = 1f;
    public float maxpaddingX = 4f;


    public void SpawnObjects()
    {

        float currentOffsetX = minOffsetX;
        while (currentOffsetX < maxOffsetX)
        {
            float randomY = Random.Range(minSpawnY, maxSpawnY);
            Vector2 spawnPosition = new Vector2(currentOffsetX, randomY);
            Instantiate(collectablePrefab, spawnPosition, Quaternion.identity, parentTransform);
            currentOffsetX += Random.Range(minpaddingX, maxpaddingX);
        }      
        
    }

}
