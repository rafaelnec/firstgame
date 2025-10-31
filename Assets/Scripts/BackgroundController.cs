using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float screenPosition = -0.355f;

    [SerializeField] private float scrollSpeed = 1f;
    private Vector3 startPosition;
    private float backgroundLength;
    private SpriteRenderer spriteRenderer;
    private Camera mainCamera;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found!");
            return;
        }

        // Store initial position and calculate background length
        startPosition = transform.position;
        backgroundLength = spriteRenderer.bounds.size.x;
        Debug.Log($"Background length: {backgroundLength}");
    }

    void Update()
    {
        // Move background left
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Convert the sprite's position to viewport coordinates
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the sprite is completely off screen to the left
        if (viewportPoint.x < screenPosition) 
        {
            // Reset to starting position
            transform.position = startPosition;
            Debug.Log("Sprite reset - moved off screen");
        }

        // Debug information
        Debug.Log($"Viewport position X: {viewportPoint.x:F2}");
        Debug.Log($"World position X: {transform.position.x:F2}");
    }
}
