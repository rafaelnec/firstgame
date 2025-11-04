using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 7f;
    public float jumpLength = 0.5f;
    public float moveSpeed = 5f;
    public float maxXPosition = 31.5f;

    private Vector3 startPlayerPosition;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private float startJumpForce;

    void Start()
    {
        startPlayerPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        animator.SetBool("isRunning", true);
        isGrounded = true;
        startJumpForce = rb.totalForce.x;
    }

    void Update()
    {

        if (transform.position.x < maxXPosition)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && animator.GetBool("isRunning"))
        {
            rb.AddForceX(jumpLength, ForceMode2D.Impulse);
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("Jump", true);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isRunning", true);
        }
    }

    public void Reload()
    {
        transform.position = startPlayerPosition;
        animator.SetBool("isRunning", true);
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

    // public void Hit()
    // {
    //     animator.SetTrigger("Fall");
    //     animator.SetBool("isRunning", false);

    //     StaticSceneController staticSceneController = FindFirstObjectByType<StaticSceneController>();
    //     staticSceneController.scrollSpeed = 0f;

    // }

}
