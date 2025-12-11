using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float lifetime = 10f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
