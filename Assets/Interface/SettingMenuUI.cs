using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenuUI : MonoBehaviour
{

  public void OnEnter()
  {
    gameObject.SetActive(true);
  }


  public void OnExit()
  {
    gameObject.SetActive(false);
  }

 
}
