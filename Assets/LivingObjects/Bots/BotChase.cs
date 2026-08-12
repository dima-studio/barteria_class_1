using UnityEngine;

public class BotChase : MonoBehaviour
{
  private TargetSelector targetSelector;
  private Movement movement;
  private Vector2 dir;
  private ObstacleScanner obstacleScanner; //1

  void Start()
  {
    obstacleScanner = GetComponent<ObstacleScanner>(); //1
    targetSelector = GetComponent<TargetSelector>();
    movement = GetComponent<Movement>();
  }

  public void BotChaseActively()
  {
    dir = targetSelector.Target.position - transform.position;
    dir.Normalize();
    obstacleScanner.ObstacleDetection(dir); //1
    //movement.Movement_ADD(dir);
  }

  void Update()
  {
  }
}
