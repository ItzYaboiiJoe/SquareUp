using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource musicSource;  // Reference to the AudioSource for background music
    public AudioSource effectsSource; // Reference to the AudioSource for sound effects

    [Header("Audio Clips")]
    public AudioClip jumpSoundClip;  // Audio clip for the jump sound
    public AudioClip backgroundMusicClip; // Audio clip for the background music

    // Singleton instance
    public static SoundManager Instance { get; private set; }

    void Awake()
    {
        // Ensure only one instance of the SoundManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist this object across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance is kept
        }
    }

    void Start()
    {
        if (musicSource == null || effectsSource == null)
        {
            Debug.LogError("AudioSource components are not assigned.");
            return;
        }

        // Initialize the mute states based on PlayerPrefs
        musicSource.mute = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        effectsSource.mute = PlayerPrefs.GetInt("EffectsMuted", 0) == 1;

        // Play background music if the clip is assigned
        if (backgroundMusicClip != null)
        {
            musicSource.clip = backgroundMusicClip;
            musicSource.loop = true; // Loop the background music
            musicSource.Play();
        }
    }

    // Method to toggle background music on and off
    public void ToggleMusic(bool isOn)
    {
        if (musicSource != null)
        {
            musicSource.mute = !isOn;
            PlayerPrefs.SetInt("MusicMuted", isOn ? 0 : 1);
        }
        else
        {
            Debug.LogWarning("Music AudioSource is missing.");
        }
    }

    // Method to toggle sound effects on and off
    public void ToggleEffects(bool isOn)
    {
        if (effectsSource != null)
        {
            effectsSource.mute = !isOn;
            PlayerPrefs.SetInt("EffectsMuted", isOn ? 0 : 1);
        }
        else
        {
            Debug.LogWarning("Effects AudioSource is missing.");
        }
    }

    // Method to play the jump sound
    public void PlayJumpSound()
    {
        if (effectsSource != null && jumpSoundClip != null)
        {
            effectsSource.PlayOneShot(jumpSoundClip);
        }
        else
        {
            Debug.LogWarning("Effects AudioSource or jump sound clip is missing.");
        }
    }
}
