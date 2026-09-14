using UnityEngine;

public class SpawnManager1 : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public static float spawnRate1 = 2.5f;
    private float timer = 0.0f;
    public float heightOffset = 10f;

    void Start()
    {
        // Optional initial spawn to preserve original behavior
        spawnEnemy();
        
    }

    void Update()
    {
        // Accumulate elapsed time
        timer += Time.deltaTime;

        if (timer >= spawnRate1)
        {
            spawnEnemy();
            timer = 0f;
        }
    }

    void spawnEnemy()
    {
        // Validate the array
        if (enemyPrefab == null || enemyPrefab.Length == 0)
        {
            Debug.LogWarning("SpawnManager: enemyPrefab array is null or empty.");
            return;
        }

        // Select a random prefab from the array
        int index = Random.Range(0, enemyPrefab.Length);
        GameObject prefabToSpawn = enemyPrefab[index];
        if (prefabToSpawn == null)
        {
            Debug.LogWarning($"SpawnManager: enemyPrefab[{index}] is null.");
            return;
        }

        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float randomY = Random.Range(lowestPoint, highestPoint);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0f);

        Instantiate(prefabToSpawn, spawnPos, transform.rotation);
    }
}
