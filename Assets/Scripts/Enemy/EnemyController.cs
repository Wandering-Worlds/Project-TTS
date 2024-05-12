using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyController : CharController, IDamageable 
{   
    protected float enemyMoveSpeed = 3f;
    protected GameObject refToPlayer;
    protected Rigidbody2D rb;
    public bool canMove = true;

    protected virtual void Awake()
    {
        refToPlayer = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

    }
    protected override void Move()
    {
        if (canMove)
        {
            Vector2 direction = refToPlayer.transform.position - transform.position;
            rb.velocity = direction.normalized * enemyMoveSpeed;
        }

    }

}