using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{

    [SerializeField] private GameObject collectablePrefab;

    [SerializeField] private Transform parentTransform;

    private bool spawned;

    public float minSpawnY = -5f; // Minimum Y position for spawning
    public float maxSpawnY = 5f; // Maximum Y position for spawning
    private float offsetAmount = 0f;

    void Start()
    {
        if (collectablePrefab == null)
        {
            Debug.LogWarning("PhaseOverSpawner: phaseOverPrefab not assigned. Nothing will be spawned.");
            return;
        }

        ResetSpawnedState();
    }

    void Update()
    {
        spawnPrefabs(false);
    }

    void spawnPrefabs(bool initialSpawn)
    {

        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        if (initialSpawn)
        {
            float currentOffsetX = 1f;
            float cameraOffsetX = Camera.main.transform.position.x + (cameraWidth / 2);
            while (currentOffsetX < cameraOffsetX)
            {
                float randomY = Random.Range(minSpawnY, maxSpawnY);
                Vector2 spawnPosition = new Vector2(currentOffsetX, randomY);
                Instantiate(collectablePrefab, spawnPosition, Quaternion.identity, parentTransform);
                currentOffsetX += Random.Range(1f, 4f);
            }

        } else {

            GameObject phaseOver = GameObject.FindWithTag("PhaseOver");
            
            if (offsetAmount > parentTransform.position.x - (cameraWidth / 2) && (phaseOver == null || offsetAmount > phaseOver.transform.position.x ))
            {                 
                float randomY = Random.Range(minSpawnY, maxSpawnY);
                Vector2 spawnPosition = new Vector2(
                    parentTransform.position.x + (cameraWidth / 2) - offsetAmount, 
                    randomY);

                Instantiate(collectablePrefab, spawnPosition, Quaternion.identity, parentTransform);
                offsetAmount -= Random.Range(1f, 4f);
            }
            
        }
        
    }

    public void ResetSpawnedState()
    {
        offsetAmount = parentTransform.position.x - Random.Range(1f, 2f);
        spawnPrefabs(true);
    }

}
