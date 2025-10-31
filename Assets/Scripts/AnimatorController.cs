using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private bool isWalking = false;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
        
        if (animator == null)
        {
            Debug.LogError("No Animator component found!");
            return;
        }
    }

    void Update()
    {
        // Get horizontal input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        // Set walking state based on horizontal movement
        isWalking = Mathf.Abs(horizontalInput) > 0;
        
        // Update animator parameter
        animator.SetBool("isWalking", isWalking);
        
        // Debug log to verify state changes
        Debug.Log($"Walking State: {isWalking}");
    }

    public bool GetIsWalking()
    {
        return isWalking;
    }

    public void SetIsWalking(bool walking)
    {
        isWalking = walking;
        if (animator != null)
        {
            animator.SetBool("isWalking", isWalking);
        }
    }
}
