using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : CharacterController
{
    protected Rigidbody2D rb;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
  
    }



    protected override void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = movement * moveSpeed;
    }

}