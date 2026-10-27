using System;
using UnityEngine;
using UnityEngine.Audio;

public class AppEntry: MonoBehaviour
{
  static AppEntry s_inst = null;

  public static AppEntry Instance
  {
    get 
    {
      return s_inst;  
    }
  }

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
    }
    SaveSettingManager.Load();
  }


  private void Start()
  {
    
  }

}

