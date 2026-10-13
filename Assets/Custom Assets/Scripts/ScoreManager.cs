using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText; 
    public float score;
    public LivesController livesController;
    public bool isGameOver = false;
    void Start()
    {
        scoreText.text = "Score: " + score.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        if (livesController == null)
        {
            return;
        }
        score += Time.deltaTime;
        scoreText.text = "Score: " + score.ToString("0");
        highScoreText.text = "Huss Score: " + score.ToString("0");
    }

    public void AddScore(int pointsToAdd) 
    {
        score += pointsToAdd;
    }
}
