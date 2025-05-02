using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;

    private float range; // Rango máximo que puede recorrer
    private Vector3 startPosition;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;

        // Verifica si la bala ha superado su rango
        if (Vector3.Distance(startPosition, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void SetRange(float range)
    {
        this.range = range;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Movimiento HeroKnight = collision.collider.GetComponent<Movimiento>();
        Bird crown = collision.collider.GetComponent<Bird>();
        // Aquí podrías poner también: Destroy(gameObject); si quieres que se destruya al impactar.
    }
}
