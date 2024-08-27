using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
    public ParticleSystem fireParticleSystem; // Renomeado para evitar conflito

    private void Start()
    {
        // Configurar o módulo de colisão do Particle System
        var collisionModule = fireParticleSystem.collision;
        collisionModule.enabled = true; // Certifique-se de que o módulo de colisão está ativado
        collisionModule.collidesWith = LayerMask.GetMask("Asteroides"); // Defina a camada com a qual as partículas colidem
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            Fire();
        }
    }

    private void Fire()
    {
        fireParticleSystem.Emit(1);
    }

    // Este método é chamado quando uma partícula colide com um collider
    private void OnParticleCollision(GameObject other)
    {
        // Destrói o objeto que colidiu com a partícula
        Destroy(other);
    }
}
