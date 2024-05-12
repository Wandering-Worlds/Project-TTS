using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float knockBackForce = 1E10f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit a Damageable Object");

        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Hit a Damageable Object");
            //Hit a Damageable Object
            damageable.TakeDamage(damage);

            //Apply Knockback to the object
            Vector2 direction = transform.position - other.transform.position;
            Debug.Log(direction);
            ApplyKnockBack(other.gameObject, direction, knockBackForce);

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

    private void ApplyKnockBack(GameObject gameObject,Vector2 direction, float force)
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
}
