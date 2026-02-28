using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private GameManager gameManager;

    private void Update()
    {
        RotateToMouse();

        if (gameManager == null || !gameManager.GameStarted)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void RotateToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector2 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Projectile projectileScript = projectile.GetComponent<Projectile>();

        if (projectileScript != null)
            projectileScript.Initialize(gameManager);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
            rb.AddForce(firePoint.right * shootForce, ForceMode2D.Impulse);
    }
}