using UnityEngine;
using UnityEngine.SceneManagement;    

public class MenuManager : MonoBehaviour
{
  public GameObject MainMenu;
  public GameObject SettingsMenu;

  public void Play()
  {
    SceneManager.LoadScene("Game");
  }

  public void ExitMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }

  public void SettingMenu()
  {
    SettingsMenu.SetActive(true);
  }

  public void ExitSettingMenu()
  {
    SettingsMenu.SetActive(false);
  }

  void Start()
  {
    SettingsMenu.SetActive(false);
  }
}
