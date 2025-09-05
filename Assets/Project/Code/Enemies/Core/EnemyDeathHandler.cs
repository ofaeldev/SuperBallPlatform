using System.Collections;
using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    public EnemySpawner Spawner;
    private bool canDie = false;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f); // tempo de spawn protection
        canDie = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canDie) return;

        if (other.CompareTag("FallZone"))
        {
            if (Spawner != null)
                Spawner.RemoveEnemy(gameObject);

            Destroy(gameObject);
        }
    }
}
