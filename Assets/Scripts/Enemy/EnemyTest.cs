using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : EnemyController
{
    //[SerializeField] protected GameObject playerObject;
    protected int EnemyTestHealth = 50;

    // Start is called before the first frame update
    protected override void Start()
    {
        maxHealth = EnemyTestHealth;
        base.Start();
        refToPlayer = GameObject.FindWithTag("Player"); ;
    }

    // Update is called once per frame
    void Update()
    {

    }


}
