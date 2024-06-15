using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

  private void Awake()
  {
    if(Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else 
    {
        Destroy(gameObject);
    }
  }

    public void GameOver()
    {
        //TODO Create a system for restarting level (despawn || repawn player
        Debug.Log("Game Over");
    }

  

}
