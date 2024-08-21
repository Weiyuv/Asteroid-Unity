using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public GameObject asteroidPrefab; // Prefab do asteroide
    public int initialAsteroidCount = 5; // Número inicial de asteroides
    public float respawnTime = 5f; // Tempo de respawn para novos asteroides
    public float boundaryX = 10f; // Limite horizontal para o respawn
    public float boundaryY = 5f;  // Limite vertical para o respawn

    private List<GameObject> asteroids; // Lista para armazenar asteroides

    void Start()
    {
        asteroids = new List<GameObject>();

        // Inicializa os asteroides
        for (int i = 0; i < initialAsteroidCount; i++)
        {
            SpawnAsteroid();
        }
    }

    void Update()
    {
        // Verifica se algum asteroide foi destruído e respawn
        for (int i = asteroids.Count - 1; i >= 0; i--)
        {
            if (asteroids[i] == null)
            {
                asteroids.RemoveAt(i);
                StartCoroutine(RespawnAsteroid());
            }
        }
    }

    void SpawnAsteroid()
    {
        // Cria um novo asteroide e adiciona à lista
        GameObject newAsteroid = Instantiate(asteroidPrefab, GetRandomPosition(), Quaternion.identity);
        asteroids.Add(newAsteroid);
    }

    IEnumerator RespawnAsteroid()
    {
        // Aguarda o tempo de respawn
        yield return new WaitForSeconds(respawnTime);

        // Cria um novo asteroide e adiciona à lista
        SpawnAsteroid();
    }

    Vector3 GetRandomPosition()
    {
        // Define uma posição aleatória fora dos limites da tela
        float x = Random.Range(-boundaryX, boundaryX);
        float y = Random.Range(-boundaryY, boundaryY);
        return new Vector3(x, y, 0f);
    }
}
