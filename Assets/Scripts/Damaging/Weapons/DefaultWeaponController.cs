using System.Collections;
using UnityEngine;

public class DefaultWeaponController : MonoBehaviour, IWeapon 
{
    protected CharacterDataScriptableObject characterData;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected ProjectileScriptableObject projectileData;
    [SerializeField] protected WeaponStatsScriptableObject weaponData;

    private bool canShoot = true;

    protected virtual void Awake()
    {
        projectilePrefab = weaponData.GetProjectilePrefab();
    }

    public virtual void InitializeWeapon(CharacterDataScriptableObject characterData)
    {
        this.characterData = characterData;
        UpdateProjectileStats();
    }

    public virtual void Fire(Vector3 spawnPoint, Vector3 target)
    {
        if (canShoot)
        {
            Shoot(spawnPoint, target);
            canShoot = false;
            StartCoroutine(ResetCooldown(characterData.attackCooldown * weaponData.attackSpeedScalingModifier));
        }
    }

    protected virtual void Shoot(Vector3 spawnPoint, Vector3 target)
    {
        DefaultShoot(spawnPoint, target);
    }

    protected Vector2 NormalizeTarget(Vector3 target)
    {
        Vector2 directionVector = (target - transform.position);
        return directionVector.normalized;
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

    private void UpdateProjectileStats()
    {
        projectileData.damage = characterData.damage * weaponData.damageScalingModifier;
        projectileData.projectileSpeed = characterData.projectileSpeed;
    }
}
