using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyController : CharController, IDamageable 
{   
    protected float enemyMoveSpeed = 3f;
    protected GameObject refToPlayer;

    protected override void Awake()
    {
        base.Awake();
        refToPlayer = GameObject.FindWithTag("Player");
    }
    protected override void Move()
    {
        Vector2 direction = refToPlayer.transform.position - transform.position;
        rb.velocity = direction.normalized * enemyMoveSpeed;
    }

    protected override IEnumerator Knockback()
    {
        Vector2 direction = transform.position - refToPlayer.transform.position;
        rb.AddForce(direction*50);
        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector3.zero;
    }

}