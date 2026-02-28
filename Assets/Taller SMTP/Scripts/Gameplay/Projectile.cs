using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameManager gameManager;

    public void Initialize(GameManager manager)
    {
        gameManager = manager;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hex"))
        {
            if (gameManager != null)
                gameManager.AddScore();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x) > 15f ||
            Mathf.Abs(transform.position.y) > 15f)
        {
            Destroy(gameObject);
        }
    }
}