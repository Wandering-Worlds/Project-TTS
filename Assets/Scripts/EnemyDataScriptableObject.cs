using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Enemy Data")]
public class EnemyDataScriptableObject : ScriptableObject
{
    public float health;
    public float speed;
    public float damage;
}
