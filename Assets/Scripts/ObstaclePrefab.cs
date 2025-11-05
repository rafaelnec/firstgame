using System.Collections.Generic;
using UnityEngine;

public class ObstaclePrefab : MonoBehaviour
{

    [SerializeField] private List<Sprite> obstacleSprites = new List<Sprite>();
    [SerializeField] private string requiredTag = "Player";
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = obstacleSprites[Random.Range(0, obstacleSprites.Count)];
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

    void OnColission(Collider2D other) {

        if (!string.IsNullOrEmpty(requiredTag) && !other.CompareTag(requiredTag))
            return;
            
        var exp = GetComponentInChildren<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.main.duration);
        
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.PlayerHit();
    }

}