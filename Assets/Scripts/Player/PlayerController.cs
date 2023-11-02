using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    protected override void Update()
    {
        base.Update();
        Move();
    }
    public override void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = movement * moveSpeed;
    }
}