using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Character Data")]
public class CharacterDataScriptableObject : ScriptableObject
{
    public float damage;
    public float projectileSpeed;
    public float projectileTimeToLive;
    public float offsetScale;

    [SerializeField] private float attacksPerSecond;

    public float attackCooldown { get; private set; }

    public float GetAttacksPerSecond()
    {
        return attacksPerSecond;
    }

    public void SetAttacksPerSecond(float attacksPerSecond)
    {
        setAttacksPerSecondFromAttackCD();
        this.attacksPerSecond = attacksPerSecond;
    }

    private void OnValidate()
    {
        setAttacksPerSecondFromAttackCD();
    }

    private void setAttacksPerSecondFromAttackCD()
    {
        attackCooldown = (1f / attacksPerSecond);
    }
}
