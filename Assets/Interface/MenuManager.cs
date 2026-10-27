using UnityEngine;
using UnityEngine.SceneManagement;    

public class MenuManager : MonoBehaviour
{
  public GameObject SettingsMenu;
  public GameObject DarkOverlay;

  public void Play()
  {
    SceneManager.LoadScene("Game");
    Time.timeScale = 1;
  }

  public void SettingMenu()
  {
    SettingsMenu.SetActive(true);
    DarkOverlay.SetActive(true);
  }

  void Start()
  {
    DarkOverlay.SetActive(false);
    SettingsMenu.SetActive(false);
  }
}
