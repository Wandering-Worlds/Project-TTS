using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float offsetScale = 1f;
    [SerializeField] private float projecitleSpeed = 10f;
    [SerializeField] private float projectileDuration = 10f;
    [SerializeField] private float cooldownTime = 3f;
    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (canShoot && Input.GetButton("Fire1"))
        {
            Shoot();
            canShoot = false;
            StartCoroutine(ResetCooldown());
        }
        
    }

    // Coroutine for resetting the shooting cooldown
    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }

    // Method for shooting the projectile
    private void Shoot()
    {
        // Get the mouse position in the game world
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position);
        direction = Vector3.Normalize(direction);
        Vector3 offset = direction * offsetScale;         

        // Instantiate the projectile and get its Rigidbody2D component
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position + offset, Quaternion.identity);

        // Find Angle of rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.eulerAngles = new Vector3 (0, 0, angle);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();        

        // Set the velocity of the projectile and start the coroutine to destroy it after a delay
        if ( rb != null)
        {
            rb.velocity = direction*projecitleSpeed;
            StartCoroutine(DestroyAfterDelay(projectile,projectileDuration));
        }
    }

    // Coroutine for destroying an object after a delay
    private IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
