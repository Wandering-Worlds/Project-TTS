using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyPrefab : Character
{
    //we can later specify enemy characteristics by using swtich cases. maybe.
    public float enemyMoveSpeed = 5f;
    public int enemyMaxHealth = 100;
    public int attackDamage = 10;
    public int defense = 10;
    public int dexterity = 5;
    public string enemyWeapon;
    protected override void Update()
    {
        base.Update(); 
        //enemy path finding
    }
}