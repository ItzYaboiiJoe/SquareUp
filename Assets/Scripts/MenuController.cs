using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Settings()
    {
        SceneManager.LoadScene("SettingScene");
    }

    public void Home()
    {
        SceneManager.LoadScene("MenuScene");
    }
}


