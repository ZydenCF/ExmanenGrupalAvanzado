using UnityEngine;

public class PlayerRunnerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float horizontalSpeed = 7f;
    [SerializeField] private float laneWidth = 7f;

    private float targetX = 0f;

    void Update()
    {
        MoveForward();
        HandleInput();
        MoveToLane();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetX -= laneWidth;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetX += laneWidth;
        }

        targetX = Mathf.Clamp(targetX, -laneWidth, laneWidth);
    }

    private void MoveToLane()
    {
        Vector3 targetPos = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, horizontalSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManagerRunner.Instance.GameOver();
        }
    }

}
