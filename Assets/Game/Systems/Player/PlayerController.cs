using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsMoving = false;
    [SerializeField] private Animator characterAnor;
    private Health health; // Reference to the Health component

    private void Update()
    {
        characterAnor.SetBool(Constants.Animation.Booleans.IsWalking, IsMoving);
    }

    private void Start()
    {
        health = GetComponent<Health>();
        HealthBar healthBar = GetComponentInChildren<HealthBar>();
        
        if (healthBar != null && health != null)
        {
            health.RegisterObserver(healthBar);
        }
    }

    // Example: Method to take damage
    public void TakeDamage(float amount)
    {
        if (health != null)
        {
            health.TakeDamage(amount);
        }
    }
}