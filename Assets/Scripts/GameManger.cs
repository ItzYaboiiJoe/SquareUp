
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    
    public static GameManger Instance;
    public void Awake(){
        if(Instance == null) Instance = this;
    }

    public float currentScore = 0f;

public bool isPlaying = false;

public void Update(){
    if(isPlaying){
        currentScore += Time.deltaTime;
    }
    if(Input.GetKeyDown("k")){
        isPlaying = true;
    }
}

public void GameOver(){
    currentScore = 0;
    isPlaying = false;
}
    public int PrettyScore(){
        return Mathf.RoundToInt(currentScore);
    }
}
