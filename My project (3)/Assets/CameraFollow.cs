using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform personaje; // Referencia al personaje
    public Vector3 offset; // Ajuste de posición (opcional)
    public float suavizado = 5f; // Velocidad de seguimiento

    void LateUpdate()
    {
        if (personaje != null)
        {
            Vector3 posicionDeseada = personaje.position + offset;
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado * Time.deltaTime);
        }
    }
}
