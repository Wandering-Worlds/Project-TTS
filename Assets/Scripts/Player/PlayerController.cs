using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public abstract class PlayerController : CharController
{
    [SerializeField] private const float OFFSET_SCALE = 1f;

    [SerializeField] protected CharacterDataScriptableObject classData;
    [SerializeField] protected GameObject weaponPrefab;

    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected IWeapon weapon;
    protected float moveSpeed;

    private bool charIsFacingRight = true;

    abstract protected void AnimateMove(float horizontalInput, float verticalInput);

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        moveSpeed = classData.moveSpeed;
    }

    protected virtual void Start()
    {
        weapon = weaponPrefab.GetComponents<IWeapon>()[0]; // weaponPrefab.GetComponent<DefaultWeaponController>();
        weapon.InitializeWeapon(classData);
    }

    protected virtual void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        FlipCharacterAccordingToMousePosition((Vector2)mousePosition);
        weapon.FollowPointer(mousePosition);
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
        AnimateMove(horizontalInput, verticalInput);
    }

    protected virtual void ShootWeapon()
    {
        if (Input.GetButton("Fire1"))
        {
            weapon.Fire(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private void FlipCharacterAccordingToMousePosition(Vector2 mousePosition)
    {
        float mousePosBasedOnCharPos = mousePosition.x - transform.position.x;

        if (!charIsFacingRight && mousePosBasedOnCharPos > 0)
        {
            Vector3 newAngles = transform.eulerAngles;
            newAngles.y = 0;
            transform.eulerAngles = newAngles;

            charIsFacingRight = true;
        }
        else if (charIsFacingRight && mousePosBasedOnCharPos < 0)
        {
            Vector3 newAngles = transform.eulerAngles;
            newAngles.y = 180;
            transform.eulerAngles = newAngles;
            charIsFacingRight = false;
        }
    }
}