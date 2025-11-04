using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PhaseOverSpawner : MonoBehaviour
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

    // Optional: also support non-trigger collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnColission(collision.collider);
    }

}