using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class invertheadset : MonoBehaviour
{
    [SerializeField] GameObject headset;
    [SerializeField] Director director;
    private float gravity = -100f;
    private float velocityY = 0f;
    private float jumpOffset = 0f;
    private float jumpForce = 30f;
    private bool isPaused = false;
    private Quaternion originalLocalRot;
    private AudioSource audioSource;

    void Enable()
    {
        transform.position = headset.transform.position;
        headset.transform.localPosition = Vector3.zero;
    }

    void Start() {
        originalLocalRot = transform.localRotation;
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (isPaused && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (jumpOffset <= 0f) {
                velocityY = jumpForce;
                audioSource.Play();
            }
        }

        velocityY += gravity * Time.deltaTime;
        jumpOffset += velocityY * Time.deltaTime;

        if (jumpOffset < 0f) {
            jumpOffset = 0f;
            velocityY = 0f;
        }
    }

    void LateUpdate()
    {
        transform.position = (headset.transform.localPosition * -1) + new Vector3(0f, jumpOffset, 0f) + new Vector3(0f, Mathf.Sin(Time.time * 20f) * .25f);
    }

    void OnTriggerEnter(Collider other) {
        PauseGame();
    }

    
    void PauseGame() {
        Time.timeScale = 0f;
        isPaused = true;
        director.GameOver();
    }

    void RestartGame() {
        Time.timeScale = 1f;
        isPaused = false;
        director.RestartGame();
    }
}