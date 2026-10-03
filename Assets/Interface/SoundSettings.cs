using UnityEngine;

public class SoundSettings : MonoBehaviour
{
  public UnityEngine.UI.Slider SliderTotalSound;
  public AudioSource MenuTotalMusic;
  public AudioSource GameTotalMusic;

  void Start()
  {
  }

  public void TotalMusic()
  {
    MenuTotalMusic.volume = SliderTotalSound.value;
    GameTotalMusic.volume = SliderTotalSound.value;
  }

  void Update()
  {
    TotalMusic();
  }
}
