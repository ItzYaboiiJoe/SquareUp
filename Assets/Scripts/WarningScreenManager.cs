using System.Collections;
using Unity.UI;
using UnityEngine;
using TMPro;

public class WarningScreenManager : MonoBehaviour
{
    public GameObject warningScreen;
    public TMP_Text warningMessageText;

    private MenuController menuController;

    private void Start()
    {
        HideWarningScreen();
        menuController = FindObjectOfType<MenuController>();
    }

    public void ShowWarningScreen(TMP_Text messageText)
    {
        warningMessageText.text = messageText.text;
        warningScreen.SetActive(true);
    }

    public void HideWarningScreen()
    {
        warningScreen.SetActive(false);
        if (menuController != null)
        {
            menuController.currentCanvas.gameObject.SetActive(true);
        }
    }

    public void ConfirmResetHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", 0);
        Debug.Log("High Score is reset");

        HideWarningScreen();
    }

    public void CancelResetHighScore()
    {
        HideWarningScreen();
        Debug.Log("Score has not been reset");
    }
}