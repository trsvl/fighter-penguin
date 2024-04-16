using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private List<EnemyManager> enemies;
    [SerializeField] private EnemyManager boss;
    [SerializeField] private Transform leftSpawnPoint;
    [SerializeField] private Transform rightSpawnPoint;
    [SerializeField] private Transform playerPoint;
    private int enemiesCount;


    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnTimer);
    }

    private void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemies.Count);
        bool isLeftSpawnSide = Random.Range(0, 2) == 0;
        Transform spawnPoint = isLeftSpawnSide ? leftSpawnPoint : rightSpawnPoint;

        EnemyManager enemy = Instantiate(enemies[randomEnemy], spawnPoint);
        enemy.enemyMovement.SetData(isLeftSpawnSide, leftSpawnPoint, rightSpawnPoint, playerPoint);

        enemiesCount++;

        SpawnBoss(spawnPoint, isLeftSpawnSide);
    }

    private void SpawnBoss(Transform spawnPoint, bool isLeftSpawnSide)
    {
        if (enemiesCount % 10 == 0)
        {
            EnemyManager enemy = Instantiate(boss, spawnPoint);
            enemy.enemyMovement.SetData(isLeftSpawnSide, leftSpawnPoint, rightSpawnPoint, playerPoint, true);
        }
    }
}
