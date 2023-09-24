using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Health health;
    private bool isAttacking;
    private bool isRespawning;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float damage = 15f;
    [SerializeField] private float followRange = 100f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Animator characterAnor;
    [SerializeField] private PlayerController player;

    private void Start()
    {
        health = GetComponent<Health>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        HealthBar healthBar = GetComponentInChildren<HealthBar>();
        
        if (healthBar != null && health != null)
        {
            health.RegisterObserver(healthBar);
        }
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
                characterAnor.SetBool(Constants.Animation.Booleans.IsWalking, false);
                if(!isAttacking)
                    StartCoroutine(AttackPlayer());
            }
            else
            {
                navMeshAgent.isStopped = false;
                characterAnor.SetBool(Constants.Animation.Booleans.IsWalking, true);
            }

            if (health.CurrentHealth <= 0f && !isRespawning)
            {
                isRespawning = true;
                StartCoroutine(Die());
            }
        }
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        characterAnor.SetBool(Constants.Animation.Booleans.IsHitting, true);
        yield return new WaitForSeconds(1f);
        characterAnor.SetBool(Constants.Animation.Booleans.IsHitting, false);
        player.TakeDamage(damage);
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
    
    public void TakeDamage(float amount)
    {
        if (health != null)
        {
            health.TakeDamage(amount);
        }
    }

    IEnumerator Die()
    {
        Debug.Log("Died");
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
