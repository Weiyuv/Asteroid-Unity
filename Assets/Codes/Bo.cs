using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bo : MonoBehaviour
{
    public BoxCollider2D myCollider;

    void OnTriggerExit2D(Collider2D other)
    {
        var exitingObj = other.transform;
        var position = exitingObj.position;
        var boundaryPosition = transform.position;
        var colliderSize = myCollider.bounds.extents;

        // Corrigido: use operadores lógicos corretos e parênteses apropriados
        if (position.x > boundaryPosition.x + colliderSize.x || position.x < boundaryPosition.x - colliderSize.x)
        {
            position.x = -position.x;
        }

        if (position.y > boundaryPosition.y + colliderSize.y || position.y < boundaryPosition.y - colliderSize.y)
        {
            position.y = -position.y;
        }

        exitingObj.position = position;
    }
}
