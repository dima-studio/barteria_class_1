using UnityEngine;

public class SoundSettings : MonoBehaviour
{
  public UnityEngine.UI.Slider SliderTotalSound;
  public AudioSource TotalSoundMusic;

  void Start()
  {
    SliderTotalSound.value = SaveSettingManager.TotalSound;
  }

  public void SliderSoundChangeTotal(float value)
  {
    SaveSettingManager.TotalSound = value;

    TotalSoundMusic.volume = SaveSettingManager.TotalSound;
  }
}
