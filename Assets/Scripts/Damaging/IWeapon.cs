using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
    public void Fire(Vector3 spawnPoint, Vector3 target);
    public void InitializeWeapon(CharacterDataScriptableObject characterData);
}
