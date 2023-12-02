using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(dirX * moveSpeed, rigidbody2D.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rigidbody2D.velocity = new Vector3(rigidbody2D.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0)
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0)
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
