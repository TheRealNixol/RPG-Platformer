using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController controller;
    private SpriteRenderer sprite_render;
    public float movementSpeed = 10f;
    private bool isFacingRight = true;
    public float jumpForce = 16f;
    public float collision_direction = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        sprite_render = GetComponent<SpriteRenderer>();
    }
    private void CheckMovementDirection() 
    {
        if (isFacingRight && controller.movementInputDirection < 0 && !controller.attacking && !controller.blocking && !controller.spellcasting)
        {
            Flip();
        }
        else if (!isFacingRight && controller.movementInputDirection > 0 && !controller.attacking && !controller.blocking && !controller.spellcasting) 
        {
            Flip();
        }
    }
    private void Flip() 
    {

        if (isFacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            //FIX ME LATER
            //sprite_render.flipX = true;
        }
        else 
        {
            transform.Rotate(0f, 180f, 0f);
            //sprite_render.flipX = false;
        }
        isFacingRight = !isFacingRight;
        
    }
    private void Move() 
    {
        if (!controller.attacking && !controller.blocking && !controller.spellcasting) 
        {
            rb.velocity = new Vector2(movementSpeed * controller.movementInputDirection, rb.velocity.y);
        }
    }
    private void Jump() 
    {
        if (controller.jumping) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            /*while (!controller.grounded) 
            {

            }*/
            controller.jumping = false; 
        }
    }

    private void Update()
    {
        CheckMovementDirection();
    }
    void FixedUpdate()
    {
        Move();
        Jump();
    }
}
