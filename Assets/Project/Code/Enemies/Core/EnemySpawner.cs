using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuração da Fase")]
    public LevelConfig levelConfig; // ScriptableObject da fase

    [Header("Prefab")]
    public GameObject enemyPrefab;

    private List<GameObject> activeEnemies = new List<GameObject>();
    private Transform player;
    private bool bossSpawned = false;
    public Transform arenaCenter;
    public float arenaRadius = 4f;

    void Start()
    {
        if (arenaCenter == null)
        {
            GameObject arena = GameObject.Find("Arena");
            if (arena != null)
                arenaCenter = arena.transform;
        }

        player = GameObject.FindWithTag("Player").transform;

        StartCoroutine(SpawnEnemiesRoutine());
        StartCoroutine(SpawnBossRoutine());
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        while (true)
        {
            if (activeEnemies.Count < levelConfig.maxEnemies)
            {
                for (int i = 0; i < levelConfig.enemiesPerWave; i++)
                {
                    if (activeEnemies.Count < levelConfig.maxEnemies)
                        SpawnRandomEnemy();
                }
            }
            yield return new WaitForSeconds(levelConfig.spawnInterval);
        }
    }

    void SpawnRandomEnemy()
    {
        Vector3 spawnPos = GetRandomSpawnPosition();
        GameObject enemyGO = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        EnemyController ec = enemyGO.GetComponent<EnemyController>();

        // escolhe tipo aleatório da lista
        EnemyData data = levelConfig.enemyTypes[Random.Range(0, levelConfig.enemyTypes.Count)];
        ec.Initialize(data, player);
        ec.Target = player;

        activeEnemies.Add(enemyGO);
        enemyGO.GetComponent<EnemyStateMachine>().Initialize(ec);

        // handler de morte/queda
        EnemyDeathHandler dh = enemyGO.AddComponent<EnemyDeathHandler>();
        dh.Spawner = this;
    }

    IEnumerator SpawnBossRoutine()
    {
        yield return new WaitForSeconds(levelConfig.bossDelay);

        if (bossSpawned)
            yield break; // já existe boss, não faz nada

        if (levelConfig.bossData == null)
        {
            Debug.LogWarning("⚠ Nenhum Boss configurado no LevelConfig!");
            yield break;
        }

        Vector3 spawnPos = GetRandomSpawnPosition();
        GameObject boss = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        if (boss == null)
        {
            Debug.LogError("❌ Prefab de inimigo está vazio no Spawner!");
            yield break;
        }

        EnemyController ec = boss.GetComponent<EnemyController>();
        if (ec == null)
        {
            Debug.LogError("❌ Prefab não tem EnemyController!");
            yield break;
        }

        ec.Initialize(levelConfig.bossData, player);
        ec.Target = player;

        // Inicializa estados
        EnemyStateMachine sm = boss.GetComponent<EnemyStateMachine>();
        if (sm != null)
            sm.Initialize(ec);

        // Adiciona handler de morte
        EnemyDeathHandler dh = boss.AddComponent<EnemyDeathHandler>();
        dh.Spawner = this;

        boss.name = "Boss_" + levelConfig.bossData.name;
        activeEnemies.Add(boss);
        bossSpawned = true;

        Debug.Log("👹 Boss Spawnado: " + boss.name);
    }


    Vector3 GetRandomSpawnPosition()
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

        Vector3 pos = new Vector3(
            Mathf.Cos(angle) * arenaRadius,
            arenaCenter.position.y + 1f, // garante que fica acima da arena
            Mathf.Sin(angle) * arenaRadius
        );

        return pos;
    }


    public void RemoveEnemy(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
            activeEnemies.Remove(enemy);

        // repõe imediatamente se não for boss
        if (!bossSpawned && activeEnemies.Count < levelConfig.maxEnemies)
        {
            SpawnRandomEnemy();
        }
    }
}
