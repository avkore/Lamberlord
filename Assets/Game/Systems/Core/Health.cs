using UnityEngine;
using System;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    public event Action<float> Damaged = delegate { };
    public event Action<float> Healed = delegate { };
    public event Action Killed = delegate { };

    [SerializeField] float _startingHealth = 100f;
    public float StartingHealth => _startingHealth;

    [SerializeField] float _maxHealth = 100;
    public float MaxHealth => _maxHealth;

    float _currentHealth;
    public float CurrentHealth
    {
        get => _currentHealth;
        set
        {
            if (value > _maxHealth)
            {
                value = _maxHealth;
            }
            if (value <= 0 && _currentHealth > 0)
            {
                Kill();
            }
            else if (value > 0 && _currentHealth <= 0)
            {
                // Handle resurrection logic if needed
            }

            _currentHealth = value;
            // Notify observers of health change
            NotifyObservers();
        }
    }

    private void Awake()
    {
        CurrentHealth = _startingHealth;
    }

    public void Heal(float amount)
    {
        CurrentHealth += amount;
        Healed.Invoke(amount);
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        Damaged.Invoke(amount);

        if (CurrentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Killed.Invoke();
        gameObject.SetActive(false);
    }

    // Observer pattern implementation
    private List<IHealthObserver> observers = new List<IHealthObserver>();

    public void RegisterObserver(IHealthObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(IHealthObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnHealthChanged(CurrentHealth, MaxHealth);
        }
    }
}
