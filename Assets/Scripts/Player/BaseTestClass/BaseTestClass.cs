using UnityEngine;

public class BaseTestClass : PlayerController
{
    protected override void AnimateMove(float horizontalInput, float verticalInput)
    {
        if(horizontalInput == 0f && verticalInput == 0f)
        {
            animator.SetBool("IsMoving", false);
        } else
        {
            animator.SetBool("IsMoving", true);
        }
        
    }
}
