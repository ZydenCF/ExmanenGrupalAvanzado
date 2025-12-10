using UnityEngine;

internal abstract class BaseEntity : MonoBehaviour
{
    private float health;
    private float maxHealth;

    protected void InitializeHealth(float startHealth)
    {
        maxHealth = startHealth;
        health = maxHealth;
    }

    protected float GetHealth()
    {
        return health;
    }

    protected void SetHealth(float value)
    {
        health = Mathf.Clamp(value, 0f, maxHealth);
    }

    protected bool CheckAlive()
    {
        return health > 0f;
    }

    protected abstract void Die();
}
