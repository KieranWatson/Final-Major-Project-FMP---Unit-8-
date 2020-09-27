using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpForce = 15f;
    public int extraJumps = 1;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;

    float mx;
    int jumpCount = 0;
    bool isGrounded;
    float jumpCoolDown;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(mx));

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        CheckGrounded();

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0,180, 0);

            animator.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);

            animator.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Run", false);
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    void Jump()
    {
        animator.SetBool("IsJumping", true);

        if (isGrounded || jumpCount < extraJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
    }

    void CheckGrounded()
    {
        if(Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        }
        else if(Time.time < jumpCoolDown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
