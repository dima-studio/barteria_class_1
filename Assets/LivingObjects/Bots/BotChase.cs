using UnityEngine;

public class BotChase : MonoBehaviour
{
  public TargetSelector targetSelector;
  private Movement movement;
  private Vector2 dir;

  void Start()
  {
    targetSelector = GetComponent<TargetSelector>();
    movement = GetComponent<Movement>();
  }

  public void BotChaseActively()
  {
    dir = targetSelector.Target.position - transform.position;
    dir.Normalize();
    movement.Movement_ADD(dir);
  }

  void Update()
  {
    /*
    if (targetSelector.Target != null)
    {
      dir = targetSelector.Target.position - transform.position;
      dir.Normalize();
      movement.Movement_ADD(dir);

    }
    */
  }
}
