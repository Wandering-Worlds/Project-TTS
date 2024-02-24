using UnityEngine;

public class BaseTestClass : PlayerController
{
 

    protected override void Move()
    {
        base.Move();

        if (rb.velocity.x < 0f)
        {
            spriteRenderer.flipX = true;

        }
        else if (rb.velocity.x > 0f)
        {
            spriteRenderer.flipX = false;
        }
    }

}
