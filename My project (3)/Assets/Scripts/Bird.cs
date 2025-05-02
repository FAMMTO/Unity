using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject target;
    private Health healthComponent;

    public GameObject bulletPrefab;
    public float attackRange = 1.0f;
    public float movementSpeed = 3f;
    public float attackCooldown = 1f;

    private float lastAttackTime;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        healthComponent = GetComponent<Health>();
    }

    private void Update()
    {
        if (target != null)
        {
            // Mover hacia el objetivo
            Vector3 directionToTarget = (target.transform.position - transform.position).normalized;
            transform.Translate(directionToTarget * movementSpeed * Time.deltaTime);

            float distance = Vector3.Distance(transform.position, target.transform.position);

            /
            if (distance < attackRange && Time.time > lastAttackTime + attackCooldown)
            {
                animator.SetTrigger("attack");
                lastAttackTime = Time.time;
            }
        }
    }

    // Este método lo llama un evento en la animación de golpe
    public void PerformAttack()
    {
        if (target == null) return;

        // Disparo
        Vector3 direction = (target.transform.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);

        // Daño
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(10);
        }
    }

    public void Hit()
    {
        if (healthComponent != null)
        {
            healthComponent.TakeDamage(10);
        }
    }
}

