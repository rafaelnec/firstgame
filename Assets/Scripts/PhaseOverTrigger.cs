using UnityEngine;


public class PhaseOverTrigger : MonoBehaviour
{
    [Tooltip("If true, only trigger when collider has this tag. Leave empty to accept any collider.")]
    [SerializeField] private string requiredTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!string.IsNullOrEmpty(requiredTag) && !other.CompareTag(requiredTag))
            return;

        Destroy(gameObject);
        
        // PhaseOverSpawner phaseOverSpawner = FindFirstObjectByType<PhaseOverSpawner>();
        // phaseOverSpawner.StartCounter();

        BackgroundController bg = FindFirstObjectByType<BackgroundController>();
        bg.AdvancePhase();

    }

    // Optional: also support non-trigger collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!string.IsNullOrEmpty(requiredTag) && !collision.collider.CompareTag(requiredTag))
            return;

        Destroy(gameObject);

        // PhaseOverSpawner phaseOverSpawner = FindFirstObjectByType<PhaseOverSpawner>();
        // phaseOverSpawner.StartCounter();

        BackgroundController bg = FindFirstObjectByType<BackgroundController>();
        bg.AdvancePhase();

    }
}