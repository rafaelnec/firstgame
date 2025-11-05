using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private Transform parentTransform;

    public float spawnY = 0f; // Minimum Y position for spawning

   public float minOffsetX = -27F;
    public float maxOffsetX = 30f;
    public float minPaddingX = 3f;
    public float maxPaddingX = 7f;


    public void SpawnObjects()
    {
        float currentOffsetX = minOffsetX;
        while (currentOffsetX < maxOffsetX)
        {
            Vector2 spawnPosition = new Vector2(currentOffsetX, spawnY);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, parentTransform);
            currentOffsetX += Random.Range(minPaddingX, maxPaddingX);
        }

    }
    
    public void ClearObjects()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(obstaclePrefab.tag);

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }
}
