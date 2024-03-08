using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour
{
    private float horizontalMovment;
    public float speed = 20f;
    public float jumpingPower = 15f;
    private bool isFacingRight = true;
    public Animator animator;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontalMovment = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", System.Math.Abs(horizontalMovment));
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpingPower);
            animator.SetTrigger("Jump");
        }

        if (Input.GetButtonUp("Jump") && rigidBody.velocity.y > 0f)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y * 0.5f);
            animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Teleport());
            
        }

 

        Flip();
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(horizontalMovment * speed, rigidBody.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }

    private void Flip()
    {
        if (isFacingRight && horizontalMovment < 0f || !isFacingRight && horizontalMovment > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    IEnumerator Teleport() {
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        animator.SetTrigger("Teleport");
        yield return null;
    }
}
