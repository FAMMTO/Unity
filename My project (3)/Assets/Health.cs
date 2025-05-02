using UnityEngine;
using UnityEngine.SceneManagement; // Importante para poder cambiar de escena

public class Health : MonoBehaviour
{
    public int maxHealth = 1; 
    private int currentHealth; // La salud actual del personaje

    void Start()
    {
        currentHealth = maxHealth; // Configurar la salud inicial
    }

    // Método para reducir la salud del personaje
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reducir la salud
        if (currentHealth <= 0)
        {
            currentHealth = 0; // Asegurarse de que la salud no sea negativa
            Die(); // Llamar al método de muerte si la salud llega a cero
        }
    }


    public int GetCurrentHealth()
    {
        return currentHealth;
    }

   
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    
    private void Die()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
