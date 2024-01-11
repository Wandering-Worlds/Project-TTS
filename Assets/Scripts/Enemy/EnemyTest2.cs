using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest2 : EnemyController
{
    protected int EnemyTest2Health = 50;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        maxHealth = EnemyTest2Health;
        enemyMoveSpeed = 1.5f;    
    }

}
