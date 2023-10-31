using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerPrefab : Character
{
    public float playerMoveSpeed = 10f;
    public int playerMaxHealth = 300;
    public int attackDamage = 20;
    public int defense = 20;
    public int dexterity = 10;
    public string playerWeapon;
    protected override void Update()
    {
        base.Update();
    }
}