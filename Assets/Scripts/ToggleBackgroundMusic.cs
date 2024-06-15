using UnityEngine;
using UnityEngine.UI;

public class ToggleBackgroundMusic : MonoBehaviour
{
    public Toggle toggle;

    void Start()
    {
        toggle.isOn = PlayerPrefs.GetInt("BackgroundMusicOn", 1) == 1;
        ToggleMusic(toggle.isOn);
    }

    public void OnToggleChange()
    {
        ToggleMusic(toggle.isOn);
        PlayerPrefs.SetInt("BackgroundMusicOn", toggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    void ToggleMusic(bool isMusicOn)
    {
        BackgroundMusic.instance.ToggleMusic(isMusicOn);
    }
}
