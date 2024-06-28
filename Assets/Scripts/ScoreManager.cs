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

    // Reference to the ObstacleSpawner script
    public ObstacleSpawner obstacleSpawner;

    void Start()
    {
        // Load high score from PlayerPrefs
        highScoreCount = PlayerPrefs.GetFloat("HighScore", 0);

        // Initialize UI texts
        scoreText.text = "Score: " + (int)scoreCount;
        highScoreText.text = "High Score: " + (int)highScoreCount;

        // Initialize obstacle spawner reference
        if (obstacleSpawner == null)
        {
            obstacleSpawner = FindObjectOfType<ObstacleSpawner>();
        }
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

        // Adjust obstacle spawner parameters based on score
        AdjustObstacleParameters();
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

    private void AdjustObstacleParameters()
    {
        // Adjust spawn interval and obstacle speed for every 100 scoreCount
        int factor = (int)(scoreCount / 100);
        float newSpawnInterval = Mathf.Max(0.5f, 6f - factor * 0.7f); // Start with 6
        float newObstacleSpeed = 50f + factor * 15f; // Start with 50

        if (obstacleSpawner.spawnInterval != newSpawnInterval || obstacleSpawner.obstacleSpeed != newObstacleSpeed)
        {
            Debug.Log($"Score: {scoreCount} - Adjusting parameters: Spawn Interval: {newSpawnInterval}, Obstacle Speed: {newObstacleSpeed}");
        }

        obstacleSpawner.spawnInterval = newSpawnInterval;
        obstacleSpawner.obstacleSpeed = newObstacleSpeed;
    }
}
