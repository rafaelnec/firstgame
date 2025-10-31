using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstaclePrefab : MonoBehaviour
{

    [SerializeField] private List<Sprite> obstacleSprites = new List<Sprite>();
    [SerializeField] private string requiredTag = "Player";

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = obstacleSprites[Random.Range(0, obstacleSprites.Count)];
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!string.IsNullOrEmpty(requiredTag) && !other.CompareTag(requiredTag))
            return;

        Explode();
        PlayerController playerController = FindFirstObjectByType<PlayerController>();
        playerController.Hit();
    }

    // Optional: also support non-trigger collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!string.IsNullOrEmpty(requiredTag) && !collision.collider.CompareTag(requiredTag))
            return;
        Explode();
        PlayerController playerController = FindFirstObjectByType<PlayerController>();
        playerController.Hit();

    }

    void Explode() {
        var exp = GetComponentInChildren<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.duration);
    }

}