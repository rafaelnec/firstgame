using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform parentTransform;

    public float spawnY = -1.30f;
    private float offsetAmount = 0f;

    void Start()
    {
        if (obstaclePrefab == null)
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
            while (currentOffsetX < cameraOffsetX) {
                Vector2 spawnPosition = new Vector2(currentOffsetX, spawnY);
                Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, parentTransform);
                currentOffsetX += Random.Range(3f, 7f);
            }

        } else {

            GameObject phaseOver = GameObject.FindWithTag("PhaseOver");

            if (offsetAmount > parentTransform.position.x - (cameraWidth / 2) && (phaseOver == null || offsetAmount > phaseOver.transform.position.x ))
            {                  
                Vector2 spawnPosition = new Vector2(
                    parentTransform.position.x + (cameraWidth / 2) - offsetAmount, 
                    spawnY);

                Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, parentTransform);
                offsetAmount -= Random.Range(3f, 7f);
            }
            
        }
        
    }


    public void ResetSpawnedState()
    {
        offsetAmount = parentTransform.position.x - Random.Range(1f, 2f);
        spawnPrefabs(true);
    }

}
