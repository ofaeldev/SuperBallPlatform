using UnityEngine;
using UnityEngine.SceneManagement;

public class FallZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reinicia cena se o player cair
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (other.CompareTag("Enemy"))
        {
            // Destroi inimigo se cair
            Destroy(other.gameObject);
        }
    }
}
