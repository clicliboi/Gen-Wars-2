using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnCenter;
    [SerializeField] private float spawnRadius = 10f;

    [Header("Wave Settings")]
    [SerializeField] private int baseEnemyCount = 3;
    [SerializeField] private float waveMultiplier = 1.5f;
    [SerializeField] private float timeBetweenWaves = 5f;

    private int currentWave = 0;
    private bool isSpawning = false;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            currentWave++;
            int enemiesToSpawn = Mathf.RoundToInt(baseEnemyCount * Mathf.Pow(waveMultiplier, currentWave - 1));

            Debug.Log($"Spawning Wave {currentWave} with {enemiesToSpawn} enemies.");

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.2f); // slight delay between spawns
            }

            // Wait before the next wave starts
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private void SpawnEnemy()
    {
        Vector2 randomPos = (Vector2)spawnCenter.position + Random.insideUnitCircle * spawnRadius;
        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }
}
