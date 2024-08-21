using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireP : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
    void Fire()
    {
        //instanciar o tiro na posicao do player e com a rotacao padrao
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //adicionar forca para cima no tiro para ele subir
        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 20, ForceMode2D.Impulse);
    }
}