using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particulasdestroy : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        // Ação ao colidir, por exemplo, destruir o objeto colidido
        Destroy(other);

        // Você também pode adicionar outros efeitos, como reduzir a vida do jogador, etc.
    }
}
