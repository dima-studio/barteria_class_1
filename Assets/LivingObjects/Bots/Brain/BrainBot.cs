using UnityEngine;

public class BrainBot : MonoBehaviour
{
  protected BotChangeDir botChangeDir;
  private Rigidbody2D RB;
  private Movement movement;

  protected virtual void OnStart()
  {
    botChangeDir = GetComponent<BotChangeDir>();
    RB = GetComponent<Rigidbody2D>();
    movement = GetComponent<Movement>();

  }

  void Start()
  {
    OnStart();
  }

  protected virtual void Brain()
  { 
    if (RB.linearVelocity.magnitude < movement.Speed * 0.7f)
    {
      botChangeDir.timeDirection = 0;
    }
    botChangeDir.BotChangeDirActively();
  }

  void Update()
  {
    Brain();
  }
}
