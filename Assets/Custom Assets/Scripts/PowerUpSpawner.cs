using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    public GameObject[] powerUpPrefab;
    public static float spawnRate2 = 7.2f;
    private float timer = 0.0f;
    public float heightOffset = 10f;
    public float xOffset = 0f;
    

    void Start()
    {
     
        
    }

    void Update()
    {
        // Accumulate elapsed time
        timer += Time.deltaTime;

        if (timer >= spawnRate2)
        {
            spawnPower();
            timer = 1.0f;  
        }
    }

    void spawnPower()
    {
        // Validate the array
        if (powerUpPrefab == null || powerUpPrefab.Length == 0)
        {
            Debug.LogWarning("SpawnManager: powerUpPrefab array is null or empty.");
            return;
        }

        // Select a random prefab from the array
        int index = Random.Range(0, powerUpPrefab.Length);
        GameObject prefabToSpawn = powerUpPrefab[index];
        if (prefabToSpawn == null)
        {
            Debug.LogWarning($"SpawnManager: powerUpPrefab[{index}] is null.");
            return;
        }

        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float leftMostPoint = transform.position.x - xOffset;
        float rightMostPoint = transform.position.x + xOffset;
        float randomY = Random.Range(lowestPoint, highestPoint);
        float randomX = Random.Range(leftMostPoint, rightMostPoint);
        Vector3 spawnPos = new Vector3(randomX, randomY, 0f);

        Instantiate(prefabToSpawn, spawnPos, transform.rotation);
    }
}
