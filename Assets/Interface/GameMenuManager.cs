using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
  public GameObject DarkOverlay;
  public GameObject PauseGamePanel;
  public GameObject SettingsMenu;

  public void ExitMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
    Time.timeScale = 0;
  }

  public void SettingMenu()
  {
    SettingsMenu.SetActive(true);
  }

  public void ContinuePlay()
  {
    DarkOverlay.SetActive(false);
    PauseGamePanel.SetActive(false);
    Time.timeScale = 1;
  }

  public void GamePause()
  {
    
    DarkOverlay.SetActive(true);
    PauseGamePanel.SetActive(true);
    Time.timeScale = 0;
  }

  void Update()
  {
    if (DarkOverlay.activeSelf == true && PauseGamePanel.activeSelf == true && Input.GetKeyDown(KeyCode.Escape) == true && SettingsMenu.activeSelf == false)
    {
      ContinuePlay();
    }
    else if (Input.GetKeyDown(KeyCode.Escape) == true)
    {
      GamePause();
    }
  }

  void Start()
  {
    DarkOverlay.SetActive(false);
    PauseGamePanel.SetActive(false);
  }
}
