using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Colosseum"))
        {
            Destroy(gameObject);
        }
    }
}
