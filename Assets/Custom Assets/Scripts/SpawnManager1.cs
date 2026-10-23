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

        // Select a random prefab from the array
        int index = Random.Range(0, enemyPrefab.Length);
        GameObject prefabToSpawn = enemyPrefab[index];
      

        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float randomY = Random.Range(lowestPoint, highestPoint);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0f);

        Instantiate(prefabToSpawn, spawnPos, transform.rotation);
    }
}
