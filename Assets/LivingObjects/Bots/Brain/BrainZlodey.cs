using UnityEngine;

public class BrainZlodey : BrainBot
{
  protected BotChase botChase;
  private TargetSelector targetSelector;

  protected override void OnStart()
  {
    base.OnStart();
    botChase = GetComponent<BotChase>();
    targetSelector = GetComponent<TargetSelector>();
  }

  void Start()
  {
    OnStart();
  }

  protected override void Brain()
  {
    if (targetSelector.Target != null)
    {
      botChase.BotChaseActively();
    }
    else
    {
      base.Brain();
    }
  }

  void Update()
  {
    Brain();
  }

}
