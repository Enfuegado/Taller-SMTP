using UnityEngine;

public class Hex : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 4f;
    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}