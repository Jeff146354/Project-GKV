using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] TextMeshProUGUI hiScoreUI;
    [SerializeField] TextMeshProUGUI restartUI;
    private float score = 0f;
    private float hiScore = 0f;


    void Start()
    {
        restartUI.enabled = false;
        hiScoreUI.text = "HI " + Mathf.FloorToInt(hiScore).ToString("D5");
    }

    // Update is called once per frame
    void Update()
    {
        score += 10f * Time.deltaTime;
        scoreUI.text = Mathf.FloorToInt(score).ToString("D5");
    }

    public void ShowGameOver() {
        restartUI.enabled = true;
        if (score > hiScore) {
            hiScore = score;
            hiScoreUI.text = "HI " + Mathf.FloorToInt(hiScore).ToString("D5");
        }
    }

    public void ResetScore() {
        score = 0f;
        restartUI.enabled = false;
    }
}
