using UnityEngine;

public class ObstacleAvoidance : MonoBehaviour
{
  ObstacleScanner Scanner;
  TargetSelector targetSelector;
  Movement movement;
  float RandomDir;
  float timeToFixError = -1f;
  Vector2 dirRight;
  Vector2 dirLeft;
  Rigidbody2D RB;

  void Start()
  {
    Scanner = GetComponent<ObstacleScanner>();
    targetSelector = GetComponent<TargetSelector>();
    movement = GetComponent<Movement>();
    RandomDir = Random.Range(-1, 1);
    RB = GetComponent<Rigidbody2D>();
  }

  public void ChooseAvoidanceDir()
  {
    Quaternion Right = Quaternion.AngleAxis(50, Vector3.forward);
    dirRight = Right * Scanner.dirCenter;
    Quaternion Left = Quaternion.AngleAxis(-50, Vector3.forward);
    dirLeft = Left * Scanner.dirCenter;

    if (targetSelector.Target != null)
      Scanner.ToTargetBeamLength = (targetSelector.Target.position - transform.position).magnitude;
    else
      Scanner.ToTargetBeamLength = Scanner.BeamLength;

    Vector2 moveDir = Vector2.zero;

    bool useRight = true;
    bool useLeft = true;

    if (Scanner.BeamCenter.distance < Scanner.BeamRight.distance && Scanner.BeamCenter.transform == targetSelector.Target)
      useRight = false;

    if (Scanner.BeamCenter.distance < Scanner.BeamLeft.distance && Scanner.BeamCenter.transform == targetSelector.Target)
      useLeft = false;


    if (Scanner.BeamCenter.transform == targetSelector.Target && (Scanner.BeamRight.transform == null || Scanner.BeamRight.transform == targetSelector.Target)
        && (Scanner.BeamLeft.transform == null || Scanner.BeamLeft.transform == targetSelector.Target))
    {
      moveDir = Scanner.dirCenter;
    }
    else if (useRight && (Scanner.BeamLeft.transform == null || Scanner.BeamLeft.transform == targetSelector.Target) && Scanner.BeamRight.transform != null)
    {
      moveDir = dirRight;
    }
    else if (useLeft && (Scanner.BeamRight.transform == null || Scanner.BeamRight.transform == targetSelector.Target) && Scanner.BeamLeft.transform != null)
    {
      moveDir = dirLeft;
    }

    if (Scanner.TestStartPointCenter != null || (Scanner.BeamCenter.transform != targetSelector.Target && Scanner.BeamRight.transform == null && Scanner.BeamLeft.transform == null)
      || (Scanner.BeamRight.distance < Scanner.BeamCenter.distance && Scanner.BeamLeft.distance < Scanner.BeamLeft.distance) || RB.linearVelocity.magnitude < movement.Speed * 0.2)
    {
      if (RandomDir >= 0)
      {
        moveDir = Quaternion.AngleAxis(Random.Range(-100, -101), Vector3.forward) * Scanner.dirCenter;;
      }
      else
      {
        moveDir = Quaternion.AngleAxis(Random.Range(100, 101), Vector3.forward) * Scanner.dirCenter;
      }
    }

    if (timeToFixError > 0f || (Scanner.BeamCenter.transform != null
                                && Scanner.BeamRight.transform != null
                                && Scanner.BeamLeft.transform != null
                                && Scanner.BeamLeft.transform != targetSelector.Target
                                && Scanner.BeamRight.transform != targetSelector.Target
                                && useRight
                                && useLeft))
    {
      if (timeToFixError < 0f)
        timeToFixError = 0.4f;

      if (RandomDir <= 0)
      {
        moveDir = Quaternion.AngleAxis(Random.Range(-80f, -120), Vector3.forward) * Scanner.dirCenter;
        timeToFixError -= Time.deltaTime;

        if (RB.linearVelocity.magnitude < movement.Speed * 0.2 && timeToFixError <= 0)
          RandomDir = 1;
      }
      else
      {
        moveDir = Quaternion.AngleAxis(Random.Range(80f, 120), Vector3.forward) * Scanner.dirCenter;
        timeToFixError -= Time.deltaTime;

        if (RB.linearVelocity.magnitude < movement.Speed * 0.2 && timeToFixError <= 0)
          RandomDir = -1;
      }
    }
    


    movement.Movement_ADD(moveDir);
  }

  void Update()
  {
  }
}
