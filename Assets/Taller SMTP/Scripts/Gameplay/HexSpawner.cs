using UnityEngine;

public class HexSpawner : MonoBehaviour
{
    [SerializeField] private GameObject hexPrefab;
    [SerializeField] private float spawnInterval = 0.5f;
    [SerializeField] private float spawnRangeX = 6f;
    [SerializeField] private float spawnY = 6f;

    private bool isSpawning = false;

    public void StartSpawning()
    {
        if (isSpawning) return;

        isSpawning = true;
        InvokeRepeating(nameof(SpawnHex), 0f, spawnInterval);
    }

    void SpawnHex()
    {
        if (!isSpawning) return;

        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, spawnY);

        Instantiate(hexPrefab, spawnPosition, Quaternion.identity);
    }

    public void StopSpawning()
    {
        isSpawning = false;
        CancelInvoke(nameof(SpawnHex));
    }
}