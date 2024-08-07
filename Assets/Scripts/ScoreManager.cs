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
        float newSpawnInterval;
        float newObstacleSpeed;

        if (scoreCount < 800)
        {
            newSpawnInterval = Mathf.Max(1.2f, 6f - factor * 0.6f); // Start with 6, limit to 1.2
            newObstacleSpeed = 50f + factor * 11f; // Start with 50, increase by 11
        }
        else if (scoreCount < 1000)
        {
            factor = (int)((scoreCount - 800) / 100); // Recalculate factor after 800 points
            newSpawnInterval = 1.2f; // Fixed at 1.2 after 800 points until 1000
            newObstacleSpeed = 138f + factor * 5f; // Start with 138, increase by 5
        }
        else
        {
            factor = (int)((scoreCount - 1000) / 100); // Recalculate factor after 1000 points
            newSpawnInterval = Mathf.Max(0.9f, 1.2f - factor * 0.3f); // Start with 1.2, limit to 0.9
            newObstacleSpeed = 148f + factor * 5f; // Start with 148, increase by 5
        }

        if (obstacleSpawner.spawnInterval != newSpawnInterval || obstacleSpawner.obstacleSpeed != newObstacleSpeed)
        {
            Debug.Log($"Score: {scoreCount} - Adjusting parameters: Spawn Interval: {newSpawnInterval}, Obstacle Speed: {newObstacleSpeed}");
        }

        obstacleSpawner.spawnInterval = newSpawnInterval;
        obstacleSpawner.obstacleSpeed = newObstacleSpeed;
    }
}
