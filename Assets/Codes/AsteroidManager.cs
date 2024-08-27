using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public GameObject asteroidPrefab; // Prefab do asteroide
    public int initialAsteroidCount = 5; // Número inicial de asteroides
    public float respawnTime = 5f; // Tempo de respawn para novos asteroides
    public float boundaryX = 20f; // Limite horizontal para o respawn
    public float boundaryY = 15f;  // Limite vertical para o respawn

    // Defina a área de não-respawn centrada nas coordenadas (18, 11)
    public Vector2 noSpawnAreaCenter = new Vector2(18f, 11f);
    public float noSpawnAreaWidth = 4f; // Largura da área de não-respawn
    public float noSpawnAreaHeight = 2f; // Altura da área de não-respawn

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
        Vector3 position;
        do
        {
            // Define uma posição aleatória fora dos limites da tela
            float x = Random.Range(-boundaryX, boundaryX);
            float y = Random.Range(-boundaryY, boundaryY);
            position = new Vector3(x, y, 0f);
        } 
        // Continue gerando uma nova posição até encontrar uma fora da área de não-respawn
        while (IsInsideNoSpawnArea(position));

        return position;
    }

    bool IsInsideNoSpawnArea(Vector3 position)
    {
        // Verifica se a posição está dentro da área de não-respawn
        float halfWidth = noSpawnAreaWidth / 2f;
        float halfHeight = noSpawnAreaHeight / 2f;

        return position.x >= noSpawnAreaCenter.x - halfWidth &&
               position.x <= noSpawnAreaCenter.x + halfWidth &&
               position.y >= noSpawnAreaCenter.y - halfHeight &&
               position.y <= noSpawnAreaCenter.y + halfHeight;
    }
}
