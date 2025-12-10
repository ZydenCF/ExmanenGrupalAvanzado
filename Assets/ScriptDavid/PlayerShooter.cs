using UnityEngine;
using UnityEngine.InputSystem;

internal class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;

    private Camera fpCamera;
    private float bulletDamage = 1f;
    private float shootCooldown = 0.3f;
    private float lastShootTime = 0f;

    private void Start()
    {
        fpCamera = GetComponentInChildren<Camera>();
        if (fpCamera == null)
        {
            fpCamera = Camera.main;
        }

        if (shootPoint == null)
        {
            CreateShootPoint();
        }
    }

    private void Update()
    {
        bool rightClick = Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame;

        if (rightClick && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    private void CreateShootPoint()
    {
        GameObject point = new GameObject("ShootPoint");
        point.transform.SetParent(transform);
        point.transform.localPosition = new Vector3(0f, 1.6f, 0.5f);
        shootPoint = point.transform;
    }

    private void Shoot()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet prefab not assigned!");
            return;
        }

        // RAYCAST AL PUNTO DEL MOUSE
        Ray ray = fpCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        Vector3 shootDirection = ray.direction;

        GameObject bulletObj = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Initialize(shootDirection, bulletDamage);
        }
    }
}