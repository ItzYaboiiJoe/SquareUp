using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    public TMP_Text gameOverScoreText;
    public TMP_Text gameOverHighScoreText;

    public float scoreCount;
    public float highScoreCount;
    public float pointsPerSecond;

    public bool scoreIncreasing;

    void Start()
    {
        // Load high score from PlayerPrefs
        highScoreCount = PlayerPrefs.GetFloat("HighScore", 0);

        // Initialize UI texts
        scoreText.text = "Score: " + (int)scoreCount;
        highScoreText.text = "High Score: " + (int)highScoreCount;
    }

    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + (int)scoreCount;
        highScoreText.text = "High Score: " + (int)highScoreCount;
    }

    void OnDestroy()
    {
        // Optionally save the high score when the script is destroyed
        PlayerPrefs.SetFloat("HighScore", highScoreCount);
    }

    public void UpdateGameOverScore()
    {
        // Update the game over score texts
        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "Score: " + (int)scoreCount;
        }

        if (gameOverHighScoreText != null)
        {
            gameOverHighScoreText.text = "High Score: " + (int)highScoreCount;
        }
    }
}
