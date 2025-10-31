using UnityEngine;

public class GroundController : MonoBehaviour
{
    public float screenPosition = -0.355f;
    public float scrollSpeed = 1f;

    private Vector3 startPosition;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;       
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
}
