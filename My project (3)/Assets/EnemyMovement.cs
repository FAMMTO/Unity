using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;      // El objetivo que seguirá
    public float speed = 2.0f;     // Velocidad de movimiento
    public float stoppingDistance = 0.5f; // Distancia mínima para dejar de moverse

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance > stoppingDistance)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

            // Voltear sprite según la dirección
            if (direction.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (direction.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);

            // Activar animación de caminar si quieres
            if (animator != null)
                animator.SetBool("running", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

            if (animator != null)
                animator.SetBool("running", false);
        }
    }
}
