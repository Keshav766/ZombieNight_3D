using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform playerRef;
    [SerializeField] float playerDetectionRangeLimit = 20f;
    [SerializeField] float attackRange = 5f;
    [SerializeField] Color gismosColor;

    NavMeshAgent enemyNavMeshRef;
    float distanceToPlayer;
    bool playerDetected = false;
    bool playerInAttckRange = false;

    void Start()
    {
        enemyNavMeshRef = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        CheckPlayerDistance();
    }

    private void CheckPlayerDistance()
    {
        distanceToPlayer = Vector3.Distance(playerRef.position, transform.position);

        if (distanceToPlayer <= playerDetectionRangeLimit)
        {
            EngagePlayer();
        }
        
    }

    void EngagePlayer()
    {
        if (distanceToPlayer >= enemyNavMeshRef.stoppingDistance)
        {
            ChasePlayer();
        }
       
        if(distanceToPlayer <= enemyNavMeshRef.stoppingDistance)
        {
            AttckPlayer();
        }
    
        
    }

    private void ChasePlayer()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        enemyNavMeshRef.SetDestination(playerRef.position);
    }

    void AttckPlayer()
    {
        GetComponent<Animator>().SetBool("attack", true);
        Debug.Log("I will attack bitch");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = gismosColor;
        Gizmos.DrawWireSphere(transform.position, playerDetectionRangeLimit);
    }
}
