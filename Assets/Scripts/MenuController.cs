using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;

    public GameObject gameOverUIScreen; //rename to avoid confused with static variable
    public static GameObject gameOverUI;

    private void Awake()
    {
        gameOverUI = gameOverUIScreen;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }

    public void Settings()
    {
        SceneManager.LoadScene("SettingScene");
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

    public void Quit()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", 0);
        Debug.Log("High Score reset to 0");
    }

    public static void GameOverLoad()
    {
        Time.timeScale = 0f;
        if (gameOverUI != null)
        {
            // Update the game over score texts
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.UpdateGameOverScore();
            }

            gameOverUI.SetActive(true);
        }
        else
        {
            Debug.Log("Game over UI not assigned");
        }
    }
}