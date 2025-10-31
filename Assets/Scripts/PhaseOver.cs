using System.Collections;
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
        Vector3 spawnPos = transform.position + spawnOffset;
        Instantiate(phaseOverPrefab, spawnPos, Quaternion.identity, parentTransform);

    }

    public void StartCounter()
    {
        StartCoroutine(SpawnAfterDelay());
    }
}