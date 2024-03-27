using System;
using System.Collections;
using UnityEngine;

public class DefaultWeaponController : MonoBehaviour, IWeapon 
{
    protected CharacterDataScriptableObject characterData;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected ProjectileScriptableObject projectileData;
    [SerializeField] protected WeaponStatsScriptableObject weaponData;

    private bool canShoot = true;
    private bool weaponIsFlippedOnYAxis = false;
    private SpriteRenderer spriteRenderer;
    private Transform bulletSpawnPointTransform;

    protected virtual void Awake()
    {
        projectilePrefab = weaponData.GetProjectilePrefab();
        spriteRenderer = GetComponent<SpriteRenderer>();
        bulletSpawnPointTransform = transform.GetChild(0);
    }

    public virtual void InitializeWeapon(CharacterDataScriptableObject characterData)
    {
        this.characterData = characterData;
        UpdateProjectileStats();
    }

    public virtual void FollowPointer(Vector3 mousePointer)
    {
        Vector3 mousePositionBasedOnWeaponPosition = mousePointer - transform.position;

        float rotationZ = Mathf.Atan2(mousePositionBasedOnWeaponPosition.y, mousePositionBasedOnWeaponPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (weaponIsFlippedOnYAxis && mousePositionBasedOnWeaponPosition.x > 0)
        {
            spriteRenderer.flipY = false;
            weaponIsFlippedOnYAxis = false;
        }
        else if (!weaponIsFlippedOnYAxis && mousePositionBasedOnWeaponPosition.x < 0)
        {
            spriteRenderer.flipY = true;
            weaponIsFlippedOnYAxis = true;
        }
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

    private void DefaultShoot(Vector3 spawnPoint, Vector3 target)
    {
        Vector2 direction = NormalizeTarget(target);
        Vector3 offset = CalculateOffset(direction);

        // Instantiate the projectile and get its Rigidbody2D component
        Quaternion finalRotation = DetermineBulletRotation();


        GameObject projectile = Instantiate(projectilePrefab, 
                                            bulletSpawnPointTransform.position,
                                            finalRotation);
        if (weaponIsFlippedOnYAxis)
            projectile.GetComponent<IProjectile>().FlipProjectile();

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

    // HELPERS

    protected Vector2 NormalizeTarget(Vector3 target)
    {
        Vector2 directionVector = (target - transform.position);
        return directionVector.normalized;
    }

    protected Vector3 CalculateOffset(Vector2 direction)
    {
        return direction * characterData.offsetScale;
    }

    private Quaternion DetermineBulletRotation()
    {
        if (weaponIsFlippedOnYAxis)
        {
            Vector3 rotationInEulerNotation = bulletSpawnPointTransform.rotation.eulerAngles;
            rotationInEulerNotation.x = 180f;
            return Quaternion.Euler(rotationInEulerNotation);
        }
        else
            return bulletSpawnPointTransform.rotation;
    }

    // COROUTINES

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
}
