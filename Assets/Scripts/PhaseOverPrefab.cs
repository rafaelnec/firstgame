using UnityEngine;

public class PhaseOverPrefab : MonoBehaviour
{
    [SerializeField] private string requiredTag = "Player";
    private GameManager gameManager;

    private void OnColission(Collider2D other)
    {
        if (!string.IsNullOrEmpty(requiredTag) && !other.CompareTag(requiredTag))
            return;

        GameManager gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdvancePhase();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnColission(other);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnColission(collision.collider);
    }

}