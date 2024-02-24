using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class CharController : MonoBehaviour
{
    protected float currentHealth;
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rb;


    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }
    
    public virtual void TakeDamage(float damage)
    {
        //if spriteRenderer is not null, call DamageFade
        if (spriteRenderer != null)
            StartCoroutine(DamageFade(0.1f));

        if (rb != null)
            StartCoroutine(Knockback());

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator DamageFade(float duraiton)
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(duraiton);

        spriteRenderer.color = originalColor;
    }

    protected abstract IEnumerator Knockback();
    

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected abstract void Move();
}