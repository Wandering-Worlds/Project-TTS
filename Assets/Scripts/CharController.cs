using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class CharController : MonoBehaviour, IDamageable
{
    protected float moveSpeed = 5f;
    protected float maxHealth = 100f;
    protected float currentHealth;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }
    
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected abstract void Move();
}