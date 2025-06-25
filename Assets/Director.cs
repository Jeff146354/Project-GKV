using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    [SerializeField] UIScript uiScript;
    [SerializeField] ObstacleSpawner obstacleSpawner;
    private AudioSource audioSource;

    
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void GameOver() {
        uiScript.ShowGameOver();
        obstacleSpawner.DeleteObstancles();
        audioSource.Play();
    }

    public void RestartGame() {
        uiScript.ResetScore();
        obstacleSpawner.Respawn();
    }
}


