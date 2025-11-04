using UnityEngine;

public class CameraController: MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float maxXPosition = 22.6f;
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Calculate the desired camera position
            Vector3 desiredPosition = playerTransform.position + offset;

            if (desiredPosition.x < maxXPosition)
            {
                transform.position = desiredPosition;
            }

        }
    }
    
    public void Reload()
    {
        cameraTransform.position = new Vector3(0, 0, cameraTransform.position.z);
    }
}
