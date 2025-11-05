using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    
    [SerializeField] private GameObject collectablePrefab;

    [SerializeField] private Transform parentTransform;

    public float minSpawnY = -1.8f; // Minimum Y position for spawning
    public float maxSpawnY = 5f; // Maximum Y position for spawning
    public float minOffsetX = -27F;
    public float maxOffsetX = 30f;
    public float minPaddingX = 1f;
    public float maxPaddingX = 4f;

    public void SpawnObjects()
    {
        float currentOffsetX = minOffsetX;
        while (currentOffsetX < maxOffsetX)
        {
            float randomY = Random.Range(minSpawnY, maxSpawnY);
            Vector2 spawnPosition = new Vector2(currentOffsetX, randomY);
            Instantiate(collectablePrefab, spawnPosition, Quaternion.identity, parentTransform);
            currentOffsetX += Random.Range(minPaddingX, maxPaddingX);
        }

    }
    
    public void ClearObjects()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(collectablePrefab.tag);

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }
}
