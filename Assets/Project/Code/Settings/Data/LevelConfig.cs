using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewLevelConfig", menuName = "Game/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [Header("Inimigos comuns")]
    public List<EnemyData> enemyTypes;

    [Header("Boss")]
    public EnemyData bossData;
    public float bossDelay = 20f;

    [Header("Configura��es de Spawn")]
    [Tooltip("m�ximo de inimigos simult�neos")]
    public int maxEnemies = 1;
    [Tooltip("quantos inimigos aparecem por vez")]
    public int enemiesPerWave = 1;
    [Tooltip("tempo entre spawns")]
    public float spawnInterval = 2f;  
}
