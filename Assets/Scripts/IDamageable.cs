using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damage);
    void CallKnockBack(Vector2 direction, float force, float duration);
    IEnumerator KnockBack(Vector2 direction, float force, float duration);
    

}
