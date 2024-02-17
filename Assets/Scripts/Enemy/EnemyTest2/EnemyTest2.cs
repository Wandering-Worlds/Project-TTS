using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest2 : EnemyController
{
    [SerializeField] private EnemyDataScriptableObject classData;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        currentHealth = classData.health;
        enemyMoveSpeed = classData.speed;    
    }

}
