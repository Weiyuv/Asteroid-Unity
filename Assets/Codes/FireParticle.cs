using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            Fire();
        }
    }

    void Fire()
    {
        particleSystem.Emit(1);
    }

    // Este método é chamado quando outro objeto entra em contato com o objeto que possui este script
    void OnParticleCollision(GameObject other)
    {
        // Destrói o objeto que colidiu com a partícula
        Destroy(other);
    }
}
