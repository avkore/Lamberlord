using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   [SerializeField] private Image healthbarSprite;
   private new Camera camera;

   public void UpdateHealthBar(float maxHealth, float currentHealth)
   {
      healthbarSprite.fillAmount = currentHealth / maxHealth;
      camera = Camera.main;
   }

   private void Update()
   {
      transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);
      healthbarSprite.fillAmount = Mathf.MoveTowards(healthbarSprite.fillAmount, 1, 2 * Time.deltaTime);
   }
}
