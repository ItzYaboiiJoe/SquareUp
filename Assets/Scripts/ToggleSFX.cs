using UnityEngine;
using UnityEngine.UI;

public class ToggleSFX : MonoBehaviour
{
    public Toggle toggle;

    void Start()
    {
        toggle.isOn = PlayerPrefs.GetInt("SFXOn", 1) == 1;
        ToggleSFXState(toggle.isOn);
    }

    public void OnToggleChange()
    {
        ToggleSFXState(toggle.isOn);
        PlayerPrefs.SetInt("SFXOn", toggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    void ToggleSFXState(bool isSFXOn)
    {
        if (isSFXOn)
        {
            SoundEffectsManager.instance.GetComponent<AudioSource>().volume = 0.05f;
        }
        else
        {
            SoundEffectsManager.instance.GetComponent<AudioSource>().volume = 0.0f;
        }
    }
}
