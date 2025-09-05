using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Movimento")]
    public float moveForce = 5f;

    [Header("Visual / Tamanho")]
    public float scale = 1f; // permite variar tamanho da bola

    [Header("Massa")]
    public float mass;

    [Header("Cor")]
    public Color color;
}
