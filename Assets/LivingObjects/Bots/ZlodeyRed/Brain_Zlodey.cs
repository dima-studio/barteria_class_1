using UnityEngine;

public class Brain_Zlodey : MonoBehaviour
{
  enum State
  {
    Patrol,
    Chace
  }
  protected BotChase botChase;
  State state_USE;

  protected virtual void OnStart()
  {
    state_USE = State.Patrol;
    botChase = GetComponent<BotChase>();
  }

  void Start()
  {
    OnStart();
  }

  protected virtual void Brain()
  {
    if (botChase.targetSelector.Target != null)
    {
      botChase.BotChaseActively();
    }

  }


  void Update()
  {
    Brain();
  }
}
