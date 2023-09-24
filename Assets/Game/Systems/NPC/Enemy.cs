using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private bool isRespawning;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float health = 100f;
    [SerializeField] private float followRange = 100f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Animator characterAnor;
    [SerializeField] private PlayerController player;
    [SerializeField] private HealthBar healthBar;

    void Start()
    {
        healthBar.UpdateHealthBar(health, health);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        
        if (distanceToPlayer <= followRange)
        {
            navMeshAgent.SetDestination(player.transform.position);
            
            if (distanceToPlayer <= attackRange)
            {
                navMeshAgent.isStopped = true;
                StartCoroutine(AttackPlayer());
            }
            else
            {
                navMeshAgent.isStopped = false;
                characterAnor.SetBool(Constants.Animation.Booleans.IsWalking, true);
            }

            if (health <= 0f && !isRespawning)
            {
                isRespawning = true;
                StartCoroutine(Die());
            } 
        }
    }

    IEnumerator AttackPlayer()
    {
        characterAnor.SetBool(Constants.Animation.Booleans.IsWalking, false);
        characterAnor.SetBool(Constants.Animation.Booleans.IsHitting, true);
        yield return new WaitForSeconds(2f);
        characterAnor.SetBool(Constants.Animation.Booleans.IsHitting, false);
    }
    
    IEnumerator Die()
    {
        Debug.Log("Enemy Died");
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject, 0.5f);
        StartCoroutine(Respawn());
    }
    
    IEnumerator Respawn()
    {
        Debug.Log("Respawning");
        yield return new WaitForSeconds(1f);
    
        float randomX = Random.Range(0f, 80);
        float randomZ = Random.Range(0f, 80);

        Vector3 enemyPosition = new Vector3(randomX, 0, randomZ);

        Debug.Log($"Respawn Position: {enemyPosition}");
        
        Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
        Debug.Log("Respawned");
    
        isRespawning = false;
    }

}