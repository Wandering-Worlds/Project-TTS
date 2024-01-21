using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerController : CharController
{
    [SerializeField] private const float OFFSET_SCALE = 1f;

    [SerializeField] protected CharacterDataScriptableObject classData;
    [SerializeField] protected GameObject weaponPrefab;
    protected Rigidbody2D rb;
    protected IWeapon weapon;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        weapon = weaponPrefab.GetComponents<IWeapon>()[0]; // weaponPrefab.GetComponent<DefaultWeaponController>();
        weapon.InitializeWeapon(classData);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        ShootWeapon();
    }

    protected override void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = movement * moveSpeed;
    }

    protected virtual void ShootWeapon()
    {
        if (Input.GetButton("Fire1"))
        {
            weapon.Fire(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}