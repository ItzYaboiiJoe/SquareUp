
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    // Reference to the Movement script
    private Movement movement;

    // Reference to the AudioManager
    public AudioManager audioManager;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    

      // Find the Movement instance in the scene
    movement = FindObjectOfType<Movement>();

        // Check if the reference is null
        if (movement == null)
        {
            Debug.LogError("Movement script not found.");
        }
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager script not found in the scene.");
        }
    }
}

