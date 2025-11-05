using UnityEngine;

public class DestroyOnTriggerExit : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
