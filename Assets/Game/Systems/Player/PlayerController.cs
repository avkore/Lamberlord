using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsMoving;
    private Health health;
    private bool isAttacking;
    [SerializeField] private Animator characterAnor;
    [SerializeField] private float damage = 20f;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var enemy = collision.gameObject.GetComponent<Enemy>();
            StartCoroutine(AttackEnemy(enemy));
        }
    }
    

    IEnumerator AttackEnemy(Enemy enemy)
    {
        characterAnor.SetBool(Constants.Animation.Booleans.IsHitting, true);
        yield return new WaitForSeconds(1f);
        characterAnor.SetBool(Constants.Animation.Booleans.IsHitting, false);
        enemy.TakeDamage(damage);
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
}