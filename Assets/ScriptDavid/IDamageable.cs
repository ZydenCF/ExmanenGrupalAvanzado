using UnityEngine;

internal interface IDamageable
{
    void TakeDamage(float damage);
    bool IsAlive();
}