using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float laneWidth = 2f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        float[] lanes = { -laneWidth, 0, laneWidth };
        float x = lanes[Random.Range(0, lanes.Length)];

        Vector3 spawnPos = new Vector3(x, -1f, transform.position.z);
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
