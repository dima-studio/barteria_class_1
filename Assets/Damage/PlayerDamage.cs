using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : TakingDamage
{
  public TMP_Text Text_HP_Player;

  void Start()
  {

  }

  public override void Death()
  {
    if (HP <= 0)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }

  void Update()
  {
    Text_HP_Player.text = "" + HP;
  }
}
