using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.25f;

    private float nextFireTime = 0f;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        RotateToMouse();

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void RotateToMouse()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        firePoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Shoot()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direction = mousePos - firePoint.position;

        GameObject bulletObject = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Bullet bullet = bulletObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SetDirection(direction);
        }
        else
        {
            Debug.LogError("El prefab de bala NO tiene el script Bullet.");
        }

    }
}