using UnityEngine;

public class ObstacleAvoidance : MonoBehaviour
{
  ObstacleScanner Scanner;
  TargetSelector targetSelector;
  Movement movement;
  float RandomDir;
  float m_timeToFixError = -1f;

  void Start()
  {
    Scanner = GetComponent<ObstacleScanner>();
    targetSelector = GetComponent<TargetSelector>();
    movement = GetComponent<Movement>();
    RandomDir = Random.Range(-1, 1);
  }

  public void ChooseAvoidanceDir()
  {
    if (targetSelector.Target != null)
      Scanner.ToTargetBeamLength = ( transform.position - targetSelector.Target.position ).magnitude ;
    else
      Scanner.ToTargetBeamLength = Scanner.BeamLength;

    Vector2 moveDir = Vector2.zero;
    bool useRight = true;
    bool useLeft = true;

    if (Scanner.BeamCenter.distance < Scanner.BeamRight.distance && Scanner.BeamCenter.collider == targetSelector.Target)
      useRight = false;

    if (Scanner.BeamCenter.distance < Scanner.BeamLeft.distance && Scanner.BeamCenter.collider == targetSelector.Target)
      useLeft = false;


    if (Scanner.BeamCenter.transform == targetSelector.Target && Scanner.BeamRight.collider == null && Scanner.BeamLeft.collider == null)
    {
      moveDir = Scanner.dirCenter;
    }

    if (useRight && Scanner.BeamRight.collider != targetSelector.Target && Scanner.BeamLeft.collider == null && Scanner.BeamRight.collider != null)
    {
      moveDir = Scanner.dirLeft;
    }

    if (useLeft && Scanner.BeamRight.collider == null && Scanner.BeamLeft.collider != targetSelector.Target && Scanner.BeamLeft.collider != null)
    {
      moveDir = Scanner.dirRight;
    }

    if (Scanner.BeamCenter.transform != targetSelector.Target && Scanner.BeamRight.collider == null && Scanner.BeamLeft.collider == null)
    {
      if (RandomDir > 0)
      {
        moveDir = Scanner.dirRight;
      }
      else
      {
        moveDir = Scanner.dirLeft;
      }
    }

    if (m_timeToFixError > 0f || ( Scanner.BeamCenter.collider != null 
                                && Scanner.BeamRight.collider != null 
                                && Scanner.BeamLeft.collider  != null 
                                && Scanner.BeamLeft.collider  != targetSelector.Target 
                                && Scanner.BeamRight.collider != targetSelector.Target
                                && useRight
                                && useLeft))
    {
      if (m_timeToFixError < 0f)
        m_timeToFixError = 0.6f;

      moveDir = Quaternion.AngleAxis(Random.Range(-70f, -130), Vector3.forward) * Scanner.dirCenter;//(Scanner.dirCenter * new Vector2(-0.5f, -0.7f)).normalized;
      m_timeToFixError -= Time.deltaTime;
    }

    movement.Movement_ADD(moveDir);

  }


  void Update()
  {
  }
}
