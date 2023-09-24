using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsMoving = false;
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private Animator characterAnor;
    [SerializeField] private MovementController dMovementController;
    [SerializeField] private HealthBar healthBar;
    
    private void Update() {
        characterAnor.SetBool(Constants.Animation.Booleans.IsWalking, IsMoving);
    }

    private void Start()
    {
        healthBar.UpdateHealthBar(health, health);
    }
}