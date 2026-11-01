using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AppEntry: MonoBehaviour
{
  public enum EGameState
  {
    MAIN_MENU,
    IN_GAME,
    PAUSE_GAME
  }

  static AppEntry s_inst = null;

  public static AppEntry Instance
  {
    get 
    {
      return s_inst;  
    }
  }

  public static EGameState GameState;

  private void Awake()
  {
    if (s_inst == null)
    {
      DontDestroyOnLoad(gameObject);
      s_inst = this;
    }
    else
    {
      Destroy(gameObject);
      return;
    }

    GameState = EGameState.MAIN_MENU;
    SaveSettingManager.Load();
    
    if (SceneManager.GetActiveScene().name == "Game")
    {
      GameState = EGameState.IN_GAME;
    }
  }

  private void Update()
  {
    Debug.Log(GameState);
  }
}

