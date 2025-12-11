using UnityEngine;

public class TrackMover : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 5f;
    [SerializeField] private float resetZ = -30f;
    [SerializeField] private float startZ = 30f;

    void Update()
    {
        transform.Translate(Vector3.back * scrollSpeed * Time.deltaTime);

        if (transform.position.z <= resetZ)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, startZ);
            transform.position = newPos;
        }
    }
}
