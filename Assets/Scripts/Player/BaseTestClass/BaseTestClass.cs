using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTestClass : PlayerController
{
    [SerializeField] protected SpriteRenderer spriteRenderer;



    protected override void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = movement * moveSpeed;

        if (horizontalInput < 0f)
        {
            spriteRenderer.flipX = true;

        }
        else if (horizontalInput > 0f)
        {
            spriteRenderer.flipX = false;
        }
    }

}
