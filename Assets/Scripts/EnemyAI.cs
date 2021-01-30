using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    
    [SerializeField] bool is2D = false;
    [SerializeField] bool isStunned = false;
    [Tooltip("Length of stun in seconds")]
    [SerializeField] float stunDelay = 1f;
    float stunTimer = 0f;

    [SerializeField] SpriteRenderer spriteRenderer;

    Vector3 destination;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    void Update()
    {
        if (isStunned)
        {
            stunTimer += Time.deltaTime;
            
            if (stunTimer >= stunDelay)
            {
                isStunned = false;
            }

            return;
        }

        destination = target.position;
        agent.destination = destination;
        
        if (!is2D)
        {
            transform.LookAt(target);
        }
    }

    public void Stun()
    {
        isStunned = true;
        stunTimer = 0f;
    }
}
