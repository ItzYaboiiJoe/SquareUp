using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// #if !UNITY_WEBGL
// using Firebase;
// using Firebase.Extensions;
// #endif

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

// #if !UNITY_WEBGL
//         InitializeFirebase();
// #endif
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

// #if !UNITY_WEBGL
//     void InitializeFirebase()
//     {
//         FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
//         {
//             var dependencyStatus = task.Result;
//             if (dependencyStatus == DependencyStatus.Available)
//             {
//                 // Firebase is ready to use
//                 Debug.Log("Firebase is ready to use.");
//             }
//             else
//             {
//                 Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
//                 // Firebase Unity SDK is not safe to use here.
//             }
//         });
//     }
// #endif

}
