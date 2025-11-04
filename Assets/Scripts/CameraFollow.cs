using UnityEngine;

public class CameraFollow: MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float maxXPosition = 22.6f;

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
}
