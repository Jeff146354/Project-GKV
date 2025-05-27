using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<Obstacle> obstacleList;   
    private float spawnInterval = 1f;
    private List<Obstacle> spawnedObstacles = new List<Obstacle>();

    private Coroutine spawnCoroutine;
    private Coroutine cleanupCoroutine;

    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnCubeRoutine());
        cleanupCoroutine = StartCoroutine(CleanupObstaclesRoutine());

        // dirty code stuff here, but who cares..
        for (int i = 1; i <= 5; i++) {
            int index = Random.Range(0, obstacleList.Count);
            Obstacle obstacle = obstacleList[index];
            Obstacle obs = Instantiate(obstacle, new Vector3(transform.position.x, 0f, 20f * i), Quaternion.identity);
            spawnedObstacles.Add(obs);
        }
    }

    IEnumerator CleanupObstaclesRoutine()
    {
        while (true)
        {
            List<Obstacle> toRemove = new List<Obstacle>();
            
            foreach (Obstacle obs in spawnedObstacles)
            {
                if (obs != null && obs.transform.position.z < -80f)
                {
                    toRemove.Add(obs);
                    Destroy(obs.gameObject);
                }
            }

            // Hapus obstacle dari list utama
            foreach (Obstacle obs in toRemove)
            {
                spawnedObstacles.Remove(obs);
            }

            yield return new WaitForSeconds(1f); // Cek setiap 1 detik
        }
    }

    IEnumerator SpawnCubeRoutine()
    {
        while (true)
        {
            SpawnCube();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnCube()
    {
        int index = Random.Range(0, obstacleList.Count);
        Obstacle obstacle = obstacleList[index];

        Obstacle obs = Instantiate(obstacle, transform.position, Quaternion.identity);
        spawnedObstacles.Add(obs);
    }

    public void DeleteObstancles()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }

        if (cleanupCoroutine != null)
        {
            StopCoroutine(cleanupCoroutine);
            cleanupCoroutine = null;
        }

        foreach (Obstacle obs in spawnedObstacles)
        {
            if (obs != null && obs.gameObject != null)
            {
                Destroy(obs.gameObject);
            }
        }
        spawnedObstacles.Clear();
    }

    public void Respawn()
    {
        spawnCoroutine = StartCoroutine(SpawnCubeRoutine());
        cleanupCoroutine = StartCoroutine(CleanupObstaclesRoutine());

        // dirty code stuff here, but who cares..
        for (int i = 1; i <= 5; i++) {
            int index = Random.Range(0, obstacleList.Count);
            Obstacle obstacle = obstacleList[index];
            Obstacle obs = Instantiate(obstacle, new Vector3(transform.position.x, 0f, 20f * i), Quaternion.identity);
            spawnedObstacles.Add(obs);
        }
    }
}