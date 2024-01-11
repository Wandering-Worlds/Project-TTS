using System.Collections;
using UnityEngine;

public class DefaultWeaponController : MonoBehaviour, IWeapon 
{
    protected CharacterDataScriptableObject characterData;
    [SerializeField] protected WeaponStatsScriptableObject weaponData;
    [SerializeField] protected GameObject projectilePrefab;

    private bool canShoot = true;

    protected virtual void Awake()
    {
        Debug.Log("Default weapon is constructed, with an INITIAL canShoot value of: " + canShoot);
        canShoot = true;
        Debug.Log("After setting, the new value is: " + canShoot);
        projectilePrefab = weaponData.GetProjectilePrefab();
    }

    public virtual void InitializeWeapon(CharacterDataScriptableObject characterData)
    {
        this.characterData = characterData;
    }

    public virtual void Fire(Vector3 spawnPoint, Vector3 target)
    {
        Debug.Log("I can Shoot? " + canShoot);
        if (canShoot)
        {
            Debug.Log("I'm inside shoot");
            Shoot(spawnPoint, target);
            StartCoroutine(ResetCooldown(characterData.attackCooldown * weaponData.attackSpeedScalingModifier));
        }
        Debug.Log("Have I shot?");
    }

    protected virtual void Shoot(Vector3 spawnPoint, Vector3 target)
    {
        DefaultShoot(spawnPoint, target);
    }

    protected Vector2 NormalizeTarget(Vector3 target)
    {
        return Vector3.Normalize(target - transform.position);
    }

    protected Vector3 CalculateOffset(Vector2 direction)
    {
        return direction * characterData.offsetScale;
    }

    protected IEnumerator ResetCooldown(float attackCooldown)
    {
        yield return new WaitForSeconds(attackCooldown);
        canShoot = true;
    }

    protected IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }

    private void DefaultShoot(Vector3 spawnPoint, Vector3 target)
    {
        Vector2 direction = NormalizeTarget(target);
        Vector3 offset = CalculateOffset(direction);

        // Instantiate the projectile and get its Rigidbody2D component
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint + offset, Quaternion.identity);
        projectile.GetComponent<IProjectile>().SetDamage(characterData.damage * weaponData.damageScalingModifier);

        // Find Angle of rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.eulerAngles = new Vector3(0, 0, angle);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Set the velocity of the projectile and start the coroutine to destroy it after a delay
        if (rb != null)
        {
            rb.velocity = direction * characterData.projectileSpeed;
            StartCoroutine(DestroyAfterDelay(projectile, characterData.projectileTimeToLive));
        }
    }
}
