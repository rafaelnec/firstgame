using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundController : MonoBehaviour
{
    public float screenPosition = -0.355f;

    public float scrollSpeed = 0f;

    // changed: use int for phase index
    [SerializeField] private int currentPhase = 0;

    private Vector3 startPosition;
    private SpriteRenderer spriteRenderer;
    private Camera mainCamera;

    [SerializeField] private List<Sprite> backgroundSprites = new List<Sprite>();

    // added: collision advance options
    [Header("Advance On Hit")]
    [SerializeField] private bool advanceOnCollision = true;      // enable/disable advancing when hit
    [SerializeField] private string collisionTag = "Player";      // only advance when collider has this tag (empty = any)
    [SerializeField] private bool resetPositionOnAdvance = true;  // reset background to startPosition when advancing

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (backgroundSprites != null && backgroundSprites.Count > 0)
            spriteRenderer.sprite = backgroundSprites[currentPhase];

        mainCamera = Camera.main;

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found!");
            return;
        }
        

        // Store initial position and calculate background length
        startPosition = transform.position;
    }

    void Update()
    {
        // Move background left
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Convert the sprite's position to viewport coordinates
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(transform.position);
        if (viewportPoint.x < screenPosition)
        {
            // reset position (or reposition) and advance the phase
            transform.position = startPosition;
        }
    }

    // added: advance phase, wrap and update sprite
    public void AdvancePhase()
    {

        Debug.Log("Advancing background phase.");
        
        if (backgroundSprites == null || backgroundSprites.Count == 0) return;

        currentPhase++;
        spriteRenderer.sortingOrder = -1;

        if (currentPhase >= backgroundSprites.Count)
        {
            currentPhase = 0;
            spriteRenderer.sortingOrder = 1;
        }

        if (spriteRenderer != null)
            spriteRenderer.sprite = backgroundSprites[currentPhase];

        if (resetPositionOnAdvance)
            transform.position = startPosition;
            

        Debug.Log($"Background advanced to phase {currentPhase}");

        this.ReloadCurrentScene();
    }

    private void ReloadCurrentScene()
    {
        CollectableController collectableController = FindFirstObjectByType<CollectableController>();
        collectableController.ResetSpawnedState();

        ObstacleController obstacleController = FindFirstObjectByType<ObstacleController>();
        obstacleController.ResetSpawnedState();
        
        PhaseOverSpawner phaseOverSpawner = FindFirstObjectByType<PhaseOverSpawner>();
        phaseOverSpawner.StartCounter();
    }


    // added: trigger-based collision (2D)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!advanceOnCollision) return;
        if (!string.IsNullOrEmpty(collisionTag))
        {
            if (!other.CompareTag(collisionTag)) return;
        }
        AdvancePhase();
    }

    // added: collision-based (2D)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!advanceOnCollision) return;
        if (!string.IsNullOrEmpty(collisionTag))
        {
            if (!collision.collider.CompareTag(collisionTag)) return;
        }
        AdvancePhase();
    }
}
