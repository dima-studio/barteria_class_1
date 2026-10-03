using UnityEngine;
using UnityEngine.SceneManagement;    

public class MenuManager : MonoBehaviour
{
  public GameObject MainMenu;
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

  public void ExitSettingMenu()
  {
    SettingsMenu.SetActive(false);
    DarkOverlay.SetActive(false);
  }

  void Start()
  {
    SettingsMenu.SetActive(false);
    DarkOverlay.SetActive(false);
  }

  void Update()
  {
    if (SettingsMenu.activeSelf == true && DarkOverlay.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
    {
      ExitSettingMenu();
    }
  }
}
