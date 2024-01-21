using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectileController : MonoBehaviour, IProjectile
{
    [SerializeField] private ProjectileScriptableObject projectileData;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            //Hit a Damageable Object
            damageable.TakeDamage(projectileData.damage);

            //Destroy Bullet
            Destroy(gameObject);
        }
    }
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Colosseum"))
        {
            Destroy(gameObject);
        }
    }
}
