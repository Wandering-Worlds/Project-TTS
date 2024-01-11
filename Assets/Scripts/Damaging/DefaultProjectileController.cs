using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectileController : MonoBehaviour, IProjectile
{
    private float damage;
    private bool projectileInitialized = false;

    public void SetDamage(float damage)
    {
        this.damage = damage;
        projectileInitialized = true;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (projectileInitialized)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                //Hit a Damageable Object
                damageable.TakeDamage(damage);

                //Destroy Bullet
                Destroy(gameObject);
            }
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Colosseum"))
        {
            Destroy(gameObject);
        }
    }
}
