using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Weapon Data")]
public class WeaponStatsScriptableObject : ScriptableObject
{
    public float damageScalingModifier = 1f;
    public float attackSpeedScalingModifier = 1f;

    [SerializeField] private GameObject projectilePrefab;

    public GameObject GetProjectilePrefab()
    {
        return projectilePrefab;
    }
}
