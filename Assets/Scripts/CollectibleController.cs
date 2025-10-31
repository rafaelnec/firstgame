using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{

    [SerializeField] private GameObject collectiblePrefab;

    [SerializeField] private Transform parentTransform;

    private bool spawned;

    public float minSpawnY = -5f; // Minimum Y position for spawning
    public float maxSpawnY = 5f; // Maximum Y position for spawning
    public float minSpawnX = 0f; // Fixed X position for spawning
    public float maxSpawnX = 10f; // Fixed X position for spawning
    public float spawnZ = 0f; // Fixed Z position for spawning
    public int numberOfPrefabsToSpawn = 10; // How many prefabs to spawn

    void Start()
    {
        if (collectiblePrefab == null)
        {
            Debug.LogWarning("PhaseOverSpawner: phaseOverPrefab not assigned. Nothing will be spawned.");
            return;
        }

        SpawnRandomPrefabs();
    }

    void SpawnRandomPrefabs()
    {

        for (int i = 0; i < numberOfPrefabsToSpawn; i++)
        {

            // Generate a random Y position
            float randomY = Random.Range(minSpawnY, maxSpawnY);
            float randomX = Random.Range(minSpawnX, maxSpawnX);

            // Create the spawn position Vector3
            Vector3 spawnPosition = new Vector3(randomX, randomY, spawnZ);

            // Instantiate the selected prefab at the random position
            Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity, parentTransform);
            
        }
    }

}
