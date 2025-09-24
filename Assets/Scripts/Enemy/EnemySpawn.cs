using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector2 spawnPoint;
    float maxSpawnTime = 4f;
    float minSpawnTime = 1f;
    float spawnRate;
    float afterSpawnRate;
    int maxEnemyCount = 5;
    int currentEnemyCount = 0;



    void Start()
    {

        afterSpawnRate = 0;
        spawnRate = Random.Range(minSpawnTime, maxSpawnTime);

    }

    void Update()
    {
        afterSpawnRate += Time.deltaTime;

        //레벨이 10 단위로 오를수록 소환되는 적의 수는 증가 
        if (UIManager.instance.viewLevel % 10 == 0)
        {
            maxEnemyCount += 10;
        }

        if (currentEnemyCount <= maxEnemyCount && afterSpawnRate >= spawnRate)
        {
            SpawnEnemy();
            afterSpawnRate = 0;
            currentEnemyCount = 0;
        }

        else return;

    }

    void SpawnEnemy()
    {
        int radomIndex = Random.Range(0, 3);
        Instantiate(enemies[radomIndex], spawnPoint, Quaternion.identity);
        currentEnemyCount++;

    }
}
