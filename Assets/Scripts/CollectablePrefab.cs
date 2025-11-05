using UnityEngine;

public class CollectablePrefab : MonoBehaviour
{
    [SerializeField] private string requiredTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!string.IsNullOrEmpty(requiredTag) && !other.CompareTag(requiredTag))
            return;

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!string.IsNullOrEmpty(requiredTag) && !collision.collider.CompareTag(requiredTag))
            return;

        Destroy(gameObject);
    }
}