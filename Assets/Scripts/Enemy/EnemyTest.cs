using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : EnemyController
{
    //[SerializeField] protected GameObject playerObject;
    protected int EnemyTestHealth = 20;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        maxHealth = EnemyTestHealth;
    }


}
