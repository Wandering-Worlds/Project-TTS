using UnityEngine;

public class BaseTestClass : PlayerController
{
    protected override void AnimateHorizontalMove(float horizontalInput)
    {
        animator.SetFloat("HorizontalVelocity", horizontalInput);
    }
}
