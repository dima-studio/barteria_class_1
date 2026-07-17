using UnityEngine;

public class BotChase : MonoBehaviour
{
  private TargetSelector targetSelector;
  private Movement movement;
  public Vector2 dir;

  void Start()
  {
    targetSelector = GetComponent<TargetSelector>();
    movement = GetComponent<Movement>();
  }

  void Update()
  {
    if (targetSelector.Target != null)
    {
      dir = targetSelector.Target.position - transform.position;
      dir.Normalize();
      movement.Movement_ADD(dir);
    }
  }
}
