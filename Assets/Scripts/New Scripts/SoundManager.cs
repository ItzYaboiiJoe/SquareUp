using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Audio sources for playing background music and sound effects
    [Header("Audio Sources")]
    public AudioSource musicSource;  // Reference to the AudioSource for background music
    public AudioSource effectsSource; // Reference to the AudioSource for sound effects

    // Audio clips for different sound effects
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
        musicSource.mute = !isOn;
        PlayerPrefs.SetInt("MusicMuted", isOn ? 0 : 1);
    }

    // Method to toggle sound effects on and off
    public void ToggleEffects(bool isOn)
    {
        effectsSource.mute = !isOn;
        PlayerPrefs.SetInt("EffectsMuted", isOn ? 0 : 1);
    }

    // Method to play the jump sound
    public void PlayJumpSound()
    {
        if (jumpSoundClip != null)
        {
            effectsSource.PlayOneShot(jumpSoundClip);
        }
    }
}


