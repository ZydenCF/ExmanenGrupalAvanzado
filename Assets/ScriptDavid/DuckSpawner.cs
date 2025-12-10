using UnityEngine;

internal class DuckSpawner : MonoBehaviour
{
    [SerializeField] private GameObject duckPrefab;

    private int rowCount = 3;
    private float rowSpacing = 2f;
    private float startHeight = 3f;

    private int ducksPerRow = 4;
    private float spawnInterval = 3f;

    private void Start()
    {
        InvokeRepeating("SpawnDucks", 0f, spawnInterval);
    }

    private void SpawnDucks()
    {
        for (int row = 0; row < rowCount; row++)
        {
            for (int i = 0; i < ducksPerRow; i++)
            {
                float y = startHeight + (row * rowSpacing);
                float x = -10f - i * 2f;
                float z = 10f;

                GameObject duck = Instantiate(duckPrefab, new Vector3(x, y, z), Quaternion.identity);

                DuckTarget target = duck.GetComponent<DuckTarget>();
                if (target != null)
                {
                    // velocidad y puntos por fila
                    float speed = 2f * (row + 1);     // fila 0=2, fila1=4, fila2=6
                    int points = row + 1;             // fila 0=1, fila1=2, fila2=3

                    target.SetSpeed(speed);
                    target.SetPoints(points);
                }
            }
        }
    }
}