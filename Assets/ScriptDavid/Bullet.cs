using UnityEngine;

internal class Bullet : MonoBehaviour
{
    private float speed = 20f;
    private float damage = 1f;
    private float lifetime = 5f;
    private Vector3 direction;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    internal void Initialize(Vector3 shootDirection, float bulletDamage)
    {
        direction = shootDirection.normalized;
        damage = bulletDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable target = other.GetComponent<IDamageable>();
        if (target != null && target.IsAlive())
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}