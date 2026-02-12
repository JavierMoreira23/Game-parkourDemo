using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    
    [Header("Events")]
    public UnityEvent<float> OnHealthChanged; // Pasa porcentaje (0-1)
    public UnityEvent OnDeath;
    
    private void Start()
    {
        currentHealth = maxHealth;
        
        Debug.Log("HealthSystem iniciado - currentHealth: " + currentHealth + " / maxHealth: " + maxHealth);
        
        // Invocar el evento para actualizar la UI inicial
        float initialPercentage = GetHealthPercentage();
        Debug.Log("Porcentaje inicial calculado: " + initialPercentage);
        
        OnHealthChanged?.Invoke(initialPercentage);
    }
    
    public void TakeDamage(float damage)
    {
        Debug.Log("━━━ TakeDamage llamado ━━━");
        Debug.Log("Damage recibido: " + damage);
        Debug.Log("Health ANTES: " + currentHealth);
        
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        Debug.Log("Health DESPUÉS: " + currentHealth);
        
        float percentage = GetHealthPercentage();
        Debug.Log("Porcentaje calculado: " + percentage + " (currentHealth: " + currentHealth + " / maxHealth: " + maxHealth + ")");
        
        OnHealthChanged?.Invoke(percentage);
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void Heal(float amount)
    {
        Debug.Log("━━━ Heal llamado ━━━");
        Debug.Log("Heal recibido: " + amount);
        Debug.Log("Health ANTES: " + currentHealth);
        
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        Debug.Log("Health DESPUÉS: " + currentHealth);
        
        float percentage = GetHealthPercentage();
        Debug.Log("Porcentaje calculado: " + percentage + " (currentHealth: " + currentHealth + " / maxHealth: " + maxHealth + ")");
        
        OnHealthChanged?.Invoke(percentage);
    }
    
    public float GetHealthPercentage()
    {
        if (maxHealth == 0)
        {
            Debug.LogError("maxHealth es 0! No se puede calcular porcentaje.");
            return 0;
        }
        
        float percentage = currentHealth / maxHealth;
        return percentage;
    }
    
    private void Die()
    {
        OnDeath?.Invoke();
        Debug.Log("Player Died!");
    }
    
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    
    public float GetMaxHealth()
    {
        return maxHealth;
    }
}