using UnityEngine;

public class LifePrefab : MonoBehaviour
{
    [SerializeField] private string requiredTag = "Player";
    private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnColission(other);
        OnDynamicObjectColission(other);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnColission(collision.collider);
        OnDynamicObjectColission(collision.collider);
    }

    private void OnColission(Collider2D other)
    {
        if (!string.IsNullOrEmpty(requiredTag) && !other.CompareTag(requiredTag))
            return;

        Destroy(gameObject);

        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AddLife();
    }
    
    void OnDynamicObjectColission(Collider2D other)
    {
    //    if (!string.IsNullOrEmpty(requiredTag) && !other.CompareTag(requiredTag))
    //         Destroy(gameObject);
    }
}