using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IHealthObserver
{
    [SerializeField] private Image healthbarSprite;
    private new Camera camera;

    private void Start()
    {
        camera = Camera.main;

        // Find the Health component on the same GameObject or a parent GameObject
        Health healthComponent = GetComponentInParent<Health>();

        if (healthComponent != null)
        {
            // Register this health bar as an observer
            healthComponent.RegisterObserver(this);
        }
    }

    private void OnDestroy()
    {
        // Unregister as an observer when the health bar is destroyed
        Health healthComponent = GetComponentInParent<Health>();

        if (healthComponent != null)
        {
            healthComponent.UnregisterObserver(this);
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);
    }

    // Implement the IHealthObserver interface
    public void OnHealthChanged(float currentHealth, float maxHealth)
    {
        // Update the health bar fill amount based on current health and max health
        healthbarSprite.fillAmount = currentHealth / maxHealth;
    }
}