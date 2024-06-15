using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Awake()
    {
        if (!PlayerPrefs.HasKey("BackgroundMusicOn"))
        {
            PlayerPrefs.SetInt("BackgroundMusicOn", 1);
        }

        if (!PlayerPrefs.HasKey("SFXOn"))
        {
            PlayerPrefs.SetInt("SFXOn", 1);
        }

        PlayerPrefs.Save();
    }
}
