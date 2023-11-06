using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int maxHealth = 100;
    public int attackDamage = 10;
    public int defense = 10;
    public int dexterity = 5;
    public string weapon; //we can later create a weapon class and use that instead of string
    protected int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }
    
    protected virtual void Update() 
    { 

    }

    public virtual void TakeDamage(int damage)
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