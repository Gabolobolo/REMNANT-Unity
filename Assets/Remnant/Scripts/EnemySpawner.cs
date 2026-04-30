using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> spawnPoints;
    public int enemyCount = 5;

    private List<GameObject> aliveEnemies = new List<GameObject>();

    public void SpawnEnemies()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab no está asignado.");
            return;
        }

        if (spawnPoints == null || spawnPoints.Count == 0)
        {
            Debug.LogError("No hay Spawn Points asignados en EnemySpawner.");
            return;
        }

        for (int i = 0; i < enemyCount; i++)
        {
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Count)];
            GameObject enemy = Instantiate(enemyPrefab, point.position, Quaternion.identity);
            aliveEnemies.Add(enemy);
        }
    }

    public bool AreEnemiesAlive()
    {
        aliveEnemies.RemoveAll(e => e == null);
        return aliveEnemies.Count > 0;
    }
}