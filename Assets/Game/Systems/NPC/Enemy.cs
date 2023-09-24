using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator characterAnor;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float health = 100f;
    [SerializeField] private float followRange = 100f;
    [SerializeField] private Transform player;
    [SerializeField] private HealthBar healthBar;

    void Start()
    {
        healthBar.UpdateHealthBar(health, health);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        characterAnor.SetBool(Constants.Animation.Booleans.IsWalking, true);
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        if (distanceToPlayer <= followRange)
        {
            navMeshAgent.SetDestination(player.position);
            
            if (distanceToPlayer <= attackRange)
            {
                characterAnor.SetBool(Constants.Animation.Booleans.IsWalking, false);
                AttackPlayer();
            }
        }
    }

    void AttackPlayer()
    {
        characterAnor.SetBool(Constants.Animation.Booleans.IsHitting, true);
        characterAnor.SetBool(Constants.Animation.Booleans.IsHitting, false);
       //TODO: Attack 
    }
}
