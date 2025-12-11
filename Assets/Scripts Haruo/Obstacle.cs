using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float lifetime = 10f;
    private ObstacleSpawner a;

    private void Awake()
    {
        a = FindAnyObjectByType<ObstacleSpawner>();
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void destroyObstacle()
    {

    }

    private void OnDestroy()
    {
        a.Score++;
    }
}
