using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PhaseOverSpawner : MonoBehaviour
{
    [Tooltip("Assign the PhaseOver prefab here")]
    [SerializeField] private GameObject phaseOverPrefab;

    [Tooltip("Delay in seconds before spawning (default = 60)")]
    [SerializeField] private float delaySeconds = 2f;

    [Tooltip("Position offset relative to this GameObject where the prefab will be spawned")]
    [SerializeField] private Vector3 spawnOffset = Vector3.zero;

    [Tooltip("Optional parent for the spawned instance")]
    [SerializeField] private Transform parentTransform;

    void Start()
    {
        if (phaseOverPrefab == null)
        {
            Debug.LogWarning("PhaseOverSpawner: phaseOverPrefab not assigned. Nothing will be spawned.");
            return;
        }

        StartCounter();
    }

    private IEnumerator SpawnAfterDelay()
    {

        yield return new WaitForSeconds(delaySeconds);

        Camera mainCamera = Camera.main;
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(transform.position);

        float screenPositionX = viewportPoint.x + spawnOffset.x;
        Vector3 spawnPos = new Vector3(screenPositionX, spawnOffset.y, 0);
        Debug.Log($"Spawning PhaseOver object after delay. {spawnPos}");
        GameObject phaseOver = Instantiate(phaseOverPrefab, spawnPos, Quaternion.identity, parentTransform);
        
        DestroyObjectsBeyond(phaseOver);

    }

    private List<GameObject> FindGameObjectsByTags(List<string> tags)
    {
        List<GameObject> allFoundObjects = new List<GameObject>();

        foreach (string tag in tags)
        {
            GameObject[] objectsWithCurrentTag = GameObject.FindGameObjectsWithTag(tag);
            allFoundObjects.AddRange(objectsWithCurrentTag);
        }

        return allFoundObjects;
    }

    private void DestroyObjectsBeyond(GameObject obj)
    {
        float destroyXPosition = obj.transform.position.x - 1f;
        List<string> tagsToCheck = new List<string> { "Obstacles", "Collectables" };

        List<GameObject> allGameObjects = FindGameObjectsByTags(tagsToCheck);

        foreach (GameObject objT in allGameObjects)
        {
            if (objT.transform.position.x > destroyXPosition)
            {
                Destroy(objT);
            }
        }
    }

    public void StartCounter()
    {
        StartCoroutine(SpawnAfterDelay());
    }
    
}