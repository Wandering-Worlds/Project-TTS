using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : CharacterController
{
    public float enemyMoveSpeed = 3f;

    protected override void Update()
    {
        base.Update();
    }

    // public override void Move(Vector2 movement)
    // {
    //     Vector2 position = transform.position;
    //     position += movement * enemyMoveSpeed * Time.deltaTime;
    //     transform.position = position;
    // }
    
}