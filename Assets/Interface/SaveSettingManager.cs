using UnityEngine;

public static class SaveSettingManager
{
  public static float TotalSound;
  
  public static void SaveTotalSound()
  {
    PlayerPrefs.SetFloat("TotalSound", TotalSound);
    PlayerPrefs.Save();
  }

}
