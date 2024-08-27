using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Rigidbody2D rdb;
    public float velocidade = 10;
   
    public SpriteRenderer fogo1, fogo2;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-0, -0, 0);
    }

    // Update is called once per frame
    void Update()
    {


    }
    //FixedUpdate � chamado a cada frame, mas � chamado com um tempo fixo
    private void FixedUpdate()
    {
        Movimentos();
    }
    /// <summary>
    /// funcao que movimenta
    /// </summary>
    void Movimentos()
    {
        if (Input.GetKey(KeyCode.D)) //se aperta a tecla D
        {
            rdb.AddTorque(-velocidade); //adiciona torque para a direita
        }
        if (Input.GetKey(KeyCode.A))
        {
            rdb.AddTorque(velocidade);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rdb.AddRelativeForce(Vector2.up * velocidade);
            fogo1.enabled = true;
            fogo2.enabled = true;
        }
        else
        {
            fogo1.enabled = false;
            fogo2.enabled = false;
        }

    }
}