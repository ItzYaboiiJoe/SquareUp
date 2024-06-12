using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource soundEffectSource;
    public bool soundEffectsOn = true;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Audio manager instance has been set");

            //load the settings 
            soundEffectsOn = PlayerPrefs.GetInt("SoundEffectsOn", 1) == 1;
            soundEffectSource.mute = !soundEffectsOn;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundEffect(AudioClip soundClip)
    {
        if(soundEffectsOn)
        {
            soundEffectSource.PlayOneShot(soundClip);
        }  
    }

    public void ToggleSoundEffects(bool isOn)
    {
    if (soundEffectSource != null)
    {
        soundEffectsOn = isOn;
        soundEffectSource.mute = !isOn;
    }
    else
    {
        Debug.LogError("AudioSource is null in AudioManager.ToggleSoundEffects");
    }
    }
}

