using UnityEngine;
using UnityEngine.SceneManagement;    

public class MenuManager : MonoBehaviour
{
  public SettingMenuUI SettingsMenu;
  public GameObject    DarkOverlay;

  public void Play()
  {
    SceneManager.LoadScene("Game");
    Time.timeScale = 1;
    AppEntry.GameState = AppEntry.EGameState.IN_GAME;
  }

  public void SettingMenu()
  {
    SettingsMenu.OnEnter();
  }

  void Start()
  {
    SettingsMenu.gameObject.SetActive(false);
  }

  
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      SettingsMenu.OnExit();
    }

    DarkOverlay.SetActive(SettingsMenu.gameObject.activeInHierarchy);
  }
}
