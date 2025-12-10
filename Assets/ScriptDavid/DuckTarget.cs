using UnityEngine;

internal class DuckTarget : BaseEntity, IDamageable, IMovable
{
    private float moveSpeed = 2f;
    private float endX = 15f;
    private int points = 1;        // puntos base (fila 1)

    private GameManager gameManager;

    private void Start()
    {
        InitializeHealth(1f);
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        Move();
        CheckOutOfBounds();
    }

    public void Move()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.x >= endX)
        {
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void SetPoints(int value)
    {
        points = value;
    }

    public void TakeDamage(float damage)
    {
        SetHealth(GetHealth() - damage);

        if (!IsAlive())
        {
            Die();
        }
    }

    public bool IsAlive()
    {
        return CheckAlive();
    }

    protected override void Die()
    {
        if (gameManager != null)
        {
            gameManager.AddScore(points);
        }

        Destroy(gameObject);
    }
}