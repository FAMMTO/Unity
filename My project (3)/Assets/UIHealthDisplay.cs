using UnityEngine;
using UnityEngine.UI;

public class UIHealthDisplay : MonoBehaviour
{
    public Text characterHealthText; // Texto para mostrar la vida del personaje
    public Text birdHealthText; // Texto para mostrar la vida del pájaro
    public GameObject character; // GameObject del personaje
    public GameObject bird; // GameObject del pájaro

    private Health characterHealthComponent; // Componente de salud del personaje
    private BirdHealth birdHealthComponent; // Componente de salud del pájaro

    void Start()
    {
        // Obtener los componentes de salud de los personajes
        characterHealthComponent = character.GetComponent<Health>();
        birdHealthComponent = bird.GetComponent<BirdHealth>();

        // Actualizar los textos de la salud inicialmente
        UpdateHealthText();
    }

    void Update()
    {
        // Actualizar los textos de la salud en cada fotograma
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        // Verificar si los componentes de salud y los textos existen
        if (characterHealthComponent != null && characterHealthText != null)
        {
            // Actualizar el texto de la salud del personaje
            characterHealthText.text = "HeroKnight Health: " + characterHealthComponent.GetCurrentHealth();
        }

        if (birdHealthComponent != null && birdHealthText != null)
        {
            // Actualizar el texto de la salud del pájaro
            birdHealthText.text = "Bird Health: " + birdHealthComponent.GetCurrentHealth();
        }
    }
}
