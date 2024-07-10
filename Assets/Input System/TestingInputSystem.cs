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
    public BoxCollider2D boxCollider2D;

    private float horizontal;
    private float speed = 4f;
    private float jumpingPower = 8f;
    private bool isFacingRight = true;

    private void Update()
    {
        rigidbody2D.velocity = new Vector2(horizontal * speed, rigidbody2D.velocity.y);

        if(!isFacingRight && horizontal > 0f)
        {
            flip();
        }
        else if(isFacingRight && horizontal < 0f)
        {
            flip();
        }
        
    }
    private bool IsGrounded()
    {
        float extraHeightText = 1f;
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraHeightText,
            groundLayer);
        Color rayColor;
        if(raycastHit2D.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y+extraHeightText), rayColor);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }

    private void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;

    } 
    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        if(context.performed && IsGrounded())
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpingPower);
        }
        if(context.canceled && rigidbody2D.velocity.x > 0f)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpingPower*0.5f);
        }
    }
}
