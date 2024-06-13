using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsSceneLoader : MonoBehaviour
{
  public void LoadSettingsScene()
    {
        SceneManager.LoadScene("SettingScene");
    }
}
