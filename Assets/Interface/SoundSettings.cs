using UnityEngine;

public class SoundSettings : MonoBehaviour
{
  public UnityEngine.UI.Slider SliderTotalSound;
  public AudioSource TotalSoundMusic;

  void Start()
  {
    SliderTotalSound.value = SaveSettingManager.TotalSound;
    TotalSoundMusic.volume = SaveSettingManager.TotalSound;
    TotalSoundMusic.Play();
  }

  public void SliderSoundChangeTotal(float value)
  {
    SaveSettingManager.TotalSound = value;

    TotalSoundMusic.volume = SaveSettingManager.TotalSound;

  }
}
