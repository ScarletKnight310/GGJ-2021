using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] bool is2D = false;
    bool isStunned = false;
    [Tooltip("Length of stun in seconds")]
    [SerializeField] float stunDelay = 1f;
    float stunTimer = 0f;
    public GameObject endgameTrig;

    Vector3 destination;
    NavMeshAgent agent;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isStunned)
        {
            stunTimer += Time.deltaTime;
            if (stunTimer >= stunDelay)
            {
                isStunned = false;
                animator.SetBool("isStunned", false);
                endgameTrig.SetActive(true);
            }

            return;
        }

        destination = target.position;
        agent.destination = destination;

        animator.SetBool("isWalking", agent.remainingDistance > agent.stoppingDistance);
        
        if (!is2D)
        {
            transform.LookAt(target);
        }
    }

    public void Stun()
    {
        isStunned = true;
        stunTimer = 0f;
        animator.SetBool("isStunned", true);
        endgameTrig.SetActive(false);
    }
}
