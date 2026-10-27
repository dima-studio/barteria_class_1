using UnityEngine;

public class SetSoundVolume : MonoBehaviour
{
  void Start()
  {
    AudioSource sound = GetComponent<AudioSource>();
    if (sound != null)
    {
      sound.volume = SaveSettingManager.TotalSound;
    }
      
  }
}
