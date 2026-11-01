using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
  public GameObject DarkOverlay;
  public GameObject PauseGamePanel;
  public SettingMenuUI SettingsMenu;

  public void ExitMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
    AppEntry.GameState = AppEntry.EGameState.MAIN_MENU;
  }

  public void SettingMenu()
  { 
    SettingsMenu.OnEnter();
  }

  public void ContinuePlay()
  {
    SettingsMenu.OnExit();
    DarkOverlay.SetActive(false);
    PauseGamePanel.SetActive(false);
    Time.timeScale = 1;
    AppEntry.GameState = AppEntry.EGameState.IN_GAME;
  }

  public void GamePause()
  {
    PauseGamePanel.SetActive(true);
    Time.timeScale = 0;
    AppEntry.GameState = AppEntry.EGameState.PAUSE_GAME;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape) && AppEntry.GameState == AppEntry.EGameState.PAUSE_GAME)
    {
      ContinuePlay();
    }
    else if (Input.GetKeyDown(KeyCode.Escape))
    {
      GamePause();
    }

    DarkOverlay.SetActive(PauseGamePanel.activeInHierarchy);
  }

  void Start()
  {
    DarkOverlay.SetActive(false);
    PauseGamePanel.SetActive(false);
    SettingsMenu.gameObject.SetActive(false);
  }
}
