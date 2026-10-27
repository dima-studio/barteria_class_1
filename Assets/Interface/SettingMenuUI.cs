using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenuUI : MonoBehaviour
{
  public GameObject DarkOverlay;

  public void ExitSettingMenu()
  {
    gameObject.SetActive(false);

    if (SceneManager.GetActiveScene().name == "MainMenu")
    {
      DarkOverlay.SetActive(false);
    }
  }
  
  void Update()
  {

    if (gameObject.activeSelf == true && DarkOverlay.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
    {
      ExitSettingMenu();
    }
  }
}
