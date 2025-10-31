using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Debug.Log("DestroyOffScreen: OnBecameInvisible called, destroying object.");
        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }
}
