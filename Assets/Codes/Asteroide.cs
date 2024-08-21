using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed = 50f;
    public float rotationSpeed = 200f;
    private float rotationDir;
    private Vector2 direction;

    void Start()
    {
        // Define a direção para o centro da tela
        rotationDir = Random.value > 0.5f ? -1f : 1f;
        direction = (Vector2.zero - (Vector2)transform.position).normalized;

        // Defina a velocidade inicial
        rb.velocity = movementSpeed * direction;
    }

    void FixedUpdate()
    {
        // Atualize a velocidade do Rigidbody2D
        rb.velocity = movementSpeed * direction;
    }

    void Update()
    {
        // Atualize a rotação do asteroide
        rb.angularVelocity = rotationDir * rotationSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tiro"))
        {
            Destroy(other.gameObject); // Destrua a bala
            Destroy(gameObject); // Destrua o asteroide
            // Aqui você pode adicionar a lógica para respawn, se necessário
        }
    }
}
