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
    [SerializeField] float turnSpeed = 20f;

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
        EngagePlayer();
    }

    private void CheckPlayerDistance()
    {
        distanceToPlayer = Vector3.Distance(playerRef.position, transform.position);

        if (distanceToPlayer <= playerDetectionRangeLimit)
        {
            playerDetected = true;
        }

    }

    void EngagePlayer()
    {
        if (playerDetected)
        {
            if (distanceToPlayer >= enemyNavMeshRef.stoppingDistance)
            {
                ChasePlayer();
            }

            if (distanceToPlayer <= enemyNavMeshRef.stoppingDistance)
            {
                FaceTarget();
                AttckPlayer();
            }
        }
    }

    public void OnDamage()
    {
        playerDetected = true;
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
    }

    void FaceTarget()
    {
        Vector3 direction = (playerRef.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = gismosColor;
        Gizmos.DrawWireSphere(transform.position, playerDetectionRangeLimit);
    }
}
