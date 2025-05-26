using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    [SerializeField] UIScript uiScript;
    [SerializeField] ObstacleSpawner obstacleSpawner;


    public void GameOver() {
        uiScript.ShowGameOver();
        obstacleSpawner.DeleteObstancles();
    }

    public void RestartGame() {
        uiScript.ResetScore();
        obstacleSpawner.Respawn();
    }
}


