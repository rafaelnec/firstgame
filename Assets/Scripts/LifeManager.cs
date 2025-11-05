using UnityEngine;

public class LifeManager : MonoBehaviour
{
    
    [SerializeField] private GameObject lifePrefab;

    [SerializeField] private Transform parentTransform;

    public float minSpawnY = -1.6f; // Minimum Y position for spawning
    public float maxSpawnY = 0.6f; // Maximum Y position for spawning
    public float minOffsetX = -10f;
    public float maxOffsetX = 30f;
    public float minPaddingX = 6f;
    public float maxPaddingX = 20f;
    public int quantity = 1;

    public void SpawnObjects()
    {
        float currentOffsetX = minOffsetX;
        while (currentOffsetX < maxOffsetX && quantity > 0)
        {
            float randomY = Random.Range(minSpawnY, maxSpawnY);
            Vector2 spawnPosition = new Vector2(currentOffsetX, randomY);
            Instantiate(lifePrefab, spawnPosition, Quaternion.identity, parentTransform);
            currentOffsetX += Random.Range(minPaddingX, maxPaddingX);
            quantity -= 1;
        }

    }
    
    public void ClearObjects()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(lifePrefab.tag);

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }
}
