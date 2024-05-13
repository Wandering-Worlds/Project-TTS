using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class CharController : MonoBehaviour
{
    protected float currentHealth;

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
    public virtual void CallKnockBack(Vector2 direction, float force, float duration)
    {
        StartCoroutine(KnockBack(direction, force, duration));
    }
    
    public virtual IEnumerator KnockBack(Vector2 direction, float force, float duration)
    {
        gameObject.GetComponent<EnemyController>().canMove = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float timer = 0;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            rb.AddForce(direction * force, ForceMode2D.Impulse);
            yield return null;
        }
        gameObject.GetComponent<EnemyController>().canMove = true;
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected abstract void Move();
}