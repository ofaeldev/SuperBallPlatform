using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    public EnemyData Data;
    public Transform Target;

    private NavMeshAgent agent;
    private Rigidbody rb;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        // Desliga controle direto do NavMesh
        agent.updatePosition = false;
        agent.updateRotation = false;
    }

    void Update()
    {
        if (Target != null)
            agent.SetDestination(Target.position);
    }
    public void Initialize(EnemyData data, Transform target)
    {
        Data = data;
        Target = target;
        ApplyData();
    }

    void FixedUpdate()
    {
        if (Target != null)
        {
            // Calcula direção para o destino
            Vector3 direction = (agent.steeringTarget - transform.position).normalized;

            // Move usando física
            rb.AddForce(direction * Data.moveForce, ForceMode.Acceleration);
        }
    }
    private void ApplyData()
    {
        if (Data == null) return;

        // ajusta escala
        transform.localScale = Vector3.one * Data.scale;

        // ajusta agente navmesh
        if (agent != null)
        {
            agent.speed = Data.moveForce;  // velocidade do navmesh
            agent.acceleration = Data.moveForce * 2f;
        }

        // ajusta física
        if (rb != null)
        {
            rb.mass = Data.mass;
        }

        // muda cor do inimigo (opcional, se tiver Renderer)
        Renderer rend = GetComponentInChildren<Renderer>();
        if (rend != null && Data.color != Color.clear)
            rend.material.color = Data.color;
    }
}
