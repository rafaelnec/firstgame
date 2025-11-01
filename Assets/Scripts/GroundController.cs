using UnityEngine;

public class GroundController : MonoBehaviour
{
   public float screenPosition = -0.355f;

    public float scrollSpeed = 0f;

    private Vector3 startPosition;
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
    }

    void Update()
    {
        // Move background left
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);

        // Convert the sprite's position to viewport coordinates
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(transform.position);
        if (viewportPoint.x < screenPosition)
        {
            // reset position (or reposition) and advance the phase
            transform.position = startPosition;
        }
    }

}
