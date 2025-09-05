using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallRepel : MonoBehaviour
{
    public float repelStrength = 15f;  // força do empurrão
    public float minDistance = 1f;     // distância mínima para começar a repelir

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody otherRb = collision.rigidbody;
        Rigidbody myRb = GetComponent<Rigidbody>();

        if (otherRb != null && myRb != null)
        {
            Vector3 direction = (otherRb.position - myRb.position).normalized;

            float distance = Vector3.Distance(myRb.position, otherRb.position);

            if (distance < minDistance)
            {
                float force = repelStrength / Mathf.Max(otherRb.mass, 0.1f);

                myRb.AddForce(-direction * force, ForceMode.Impulse);
                otherRb.AddForce(direction * force, ForceMode.Impulse);
            }
        }
    }
}
