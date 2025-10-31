using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;

    private float jumpForce = 10f;
    private bool isGrounded;

    void Start()
    {
        // Get components
        // spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found!");
        }

        if (animator == null)
        {
            Debug.LogError("Animator component not found!");
        }
        else
        {
            // Set animator condition isRunning = true so transitions that depend on it start active
            animator.SetBool("isRunning", true);

        }
    }

    void Update()
    {
        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump!");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("Jump", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player is grounded when colliding with something below
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
    }
}
