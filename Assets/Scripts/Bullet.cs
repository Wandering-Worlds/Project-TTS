using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 10;



    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.CompareTag("Enemy1"))
        {
            other.GetComponent<EnemyTest>().TakeDamage(damage);

            // Destroy the bullet on impact
            Destroy(gameObject);

        }
        if (other.CompareTag("Enemy2"))
        {
            other.GetComponent<EnemyTest2>().TakeDamage(damage);

            // Destroy the bullet on impact
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
