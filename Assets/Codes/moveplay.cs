using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-0, -0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }
    void Movimento()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if(transform.position.x  < 8)
            transform.position += new Vector3(10, 0, 0) * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -8)
                transform.position += new Vector3(-10, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > -4)
                transform.position += new Vector3(0, -10, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y < 4)
                transform.position += new Vector3(0, 10, 0) * Time.deltaTime;
        }
    }
    


}
