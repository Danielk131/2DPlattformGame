using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class TestingInputSystem : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public CapsuleCollider2D capsuleCollider2D;

    private float horizontal;
    private float speed = 4f;
    private float jumpingPower = 8f;
    private bool isFacingRight = true;

    public float fallMultiplier=2.5f;
    public float lowJumpMultiplier=2.5f;

    public Animator animator;

    private void Update()
    {
        animator = GetComponent<Animator>();

        SetAnimation();
        if(rigidbody2D.velocity.y < 0)
        {
            rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(horizontal * speed, rigidbody2D.velocity.y);


    }
    private bool IsGrounded()
    {
        float extraHeightText = 1f;
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(capsuleCollider2D.bounds.center, capsuleCollider2D.bounds.size, 0f, Vector2.down, extraHeightText,
            groundLayer);
        Color rayColor;
        if (raycastHit2D.collider != null)
        {
            rayColor = Color.green;
            animator.SetBool("Jump", true);

        }
        else
        {
            rayColor = Color.red;
            Debug.Log("Er på bakken!");

        }
        Debug.DrawRay(capsuleCollider2D.bounds.center, Vector2.down * (capsuleCollider2D.bounds.extents.y + extraHeightText), rayColor);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        Debug.Log(horizontal);


    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpingPower);
            animator.SetBool("Jump", true);
        }
        if (context.canceled && rigidbody2D.velocity.x > 0f)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpingPower * 0.5f);

        }
    }

    public void OnLanding()
    {
        animator.SetBool("Jump", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (IsGrounded())
        {
            animator.SetBool("Jump", false);
        }
        Debug.Log(animator.GetBool("Jump"));


    }

    void OnDrawGizmos()
    {
        if (capsuleCollider2D != null)
        {
            Gizmos.color = Color.red;
            // Draw a box around the character's collider
            Gizmos.DrawWireCube(capsuleCollider2D.bounds.center, capsuleCollider2D.bounds.size);
        }
    }

    private void SetAnimation()
    {
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
            animator.SetFloat("MoveDirection", 1);
            Debug.Log("Høyre!");
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
            animator.SetFloat("MoveDirection", 1);
            Debug.Log("Venstre");
        }
        else if (horizontal == 0)
        {
            animator.SetFloat("MoveDirection", horizontal);

        }
        else {
            animator.SetFloat("MoveDirection", 1);
        }
    }
}

