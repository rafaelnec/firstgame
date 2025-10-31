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
    public float minSpawnDistance = 2f; // Minimum distance between prefabs
    private List<Vector2> spawnedPositions = new List<Vector2>();

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
            Vector2 spawnPosition = Vector2.zero;
            bool positionFound = false;
            int maxAttempts = 100; // Prevent infinite loops if no space is found

            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {

                // Generate a random Y position
                float randomY = Random.Range(minSpawnY, maxSpawnY);
                float randomX = Random.Range(minSpawnX, maxSpawnX);
                spawnPosition = new Vector2(randomX, randomY);

                // Instantiate the selected prefab at the random position
                // Instantiate(obsticlePrefab, spawnPosition, Quaternion.identity, parentTransform);


                // Check if this position is far enough from existing prefabs
                bool tooClose = false;
                foreach (Vector2 existingPos in spawnedPositions)
                {
                    if (Vector2.Distance(spawnPosition, existingPos) < minSpawnDistance)
                    {
                        tooClose = true;
                        break;
                    }
                }

                if (!tooClose)
                {
                    positionFound = true;
                    spawnedPositions.Add(spawnPosition);
                    break; // Exit attempt loop, position found
                }
            }

            if (positionFound)
            {
                // Randomly select a prefab from the array
                // GameObject prefabToInstantiate = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];
                Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity, parentTransform);
            }
        }

    }

}
