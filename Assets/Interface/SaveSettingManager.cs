using UnityEngine;

public static class SaveSettingManager
{
  private const string TotalSound_key = "TotalSound";
  
  public static float TotalSound = 0.5f;


  public static void Load()
  {
    TotalSound = PlayerPrefs.GetFloat(TotalSound_key, 0.5f);
  }

  public static void SaveTotalSound()
  {
    PlayerPrefs.SetFloat(TotalSound_key, TotalSound);
    PlayerPrefs.Save();
  }

}
