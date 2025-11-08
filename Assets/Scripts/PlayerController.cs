using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 5.5f;
    public float jumpLength = -2f;
    public float moveSpeed = 5f;
    public float maxXPosition = 31.5f;
    public string groundTag = "Ground";

    private Vector3 startPlayerPosition;
    
    private Rigidbody2D rb;
    private Animator animator;
    private float startMoveSpeed;
    private float startJumpLength;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        startPlayerPosition = transform.position;
        startMoveSpeed = moveSpeed;
        startJumpLength = jumpLength;

        animator.SetBool("isRunning", false);
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && animator.GetBool("isGrounded"))
        {

            if (animator.GetBool("isRunning"))
            {
                rb.AddForceX(jumpLength, ForceMode2D.Impulse);
                rb.AddForceY(jumpForce, ForceMode2D.Impulse);
                animator.SetBool("isGrounded", false);
                animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("isRunning", true);
            }
        }
    }

    void FixedUpdate()
    {
        if (transform.position.x < maxXPosition && animator.GetBool("isRunning"))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    public void Reload()
    {
        animator.SetTrigger("Reload");
        animator.SetBool("isGrounded", true);
        animator.SetBool("isRunning", false);
        rb.AddForceX(-jumpLength, ForceMode2D.Impulse);
        transform.position = startPlayerPosition;
        moveSpeed = startMoveSpeed;
        jumpLength = startJumpLength;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!string.IsNullOrEmpty(groundTag) && !collision.collider.CompareTag(groundTag))
            return;

        if (this.enabled)
            animator.SetBool("isGrounded", true);
    }

    public void Hit()
    {
        rb.AddForceX(-jumpLength, ForceMode2D.Impulse);
        transform.Translate(Vector3.zero);
        animator.SetTrigger("Fall");
        animator.SetBool("isRunning", false);

    }

    public void PlayRunning()
    {
        AudioManager audioManager = FindFirstObjectByType<AudioManager>();
        audioManager.PlayerRunningSound();
    }

}
