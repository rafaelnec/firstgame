using UnityEngine;

public class DestroyOnTriggerExit : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("DestroyOffScreen: OnBecameInvisible called, destroying object.");
        // Destroy the GameObject that exited the trigger
        Destroy(other.gameObject);
    }
}
