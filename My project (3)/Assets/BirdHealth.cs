using UnityEngine;

public class BirdHealth : MonoBehaviour
{
    public int maxHealth = 10; // Salud máxima del pájaro
    private int currentHealth; // Salud actual del pájaro

    private void Start()
    {
        currentHealth = maxHealth; // Configurar la salud inicial
    }

    // Método para reducir la salud del pájaro
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reducir la salud
        if (currentHealth <= 0)
        {
            currentHealth = 0; // Asegurar que la salud no sea negativa
            Die(); // Llamar al método de muerte si la salud llega a cero
        }
    }

    // Método para obtener la salud actual del pájaro
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    // Método para obtener la salud máxima del pájaro
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    // Método para manejar la muerte del pájaro
    private void Die()
    {
        // Agregar aquí cualquier lógica de muerte, como reproducir una animación o desactivar el GameObject.
        Destroy(gameObject);
    }
}
