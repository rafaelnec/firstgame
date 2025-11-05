using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 5.5f;
    public float jumpLength = -2.5f;
    public float moveSpeed = 5f;
    public float maxXPosition = 31.5f;
    public string groundTag = "Ground";

    private Vector3 startPlayerPosition;
    
    private Rigidbody2D rb;
    private Animator animator;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        startPlayerPosition = transform.position;
        animator.SetBool("isRunning", true);
    }

    void Update()
    {

        if (transform.position.x < maxXPosition && animator.GetBool("isRunning"))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
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

    public void Reload()
    {
        transform.position = startPlayerPosition;
        animator.SetBool("isRunning", true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!string.IsNullOrEmpty(groundTag) && !collision.collider.CompareTag(groundTag))
            return;

        animator.SetBool("isGrounded", true);
    }

    public void Hit()
    {
        rb.AddForceX(-jumpLength, ForceMode2D.Impulse);
        transform.Translate(Vector3.zero);
        animator.SetTrigger("Fall");
        animator.SetBool("isRunning", false);

    }

}
