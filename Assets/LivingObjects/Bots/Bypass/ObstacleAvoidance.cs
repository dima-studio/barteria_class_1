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
  //VisionCollider visionCollider;
  //float ObjectDistance;
  //Collider2D TargetCollider;

  //public int m_debugId;

  void Start()
  {
    //visionCollider = GetComponentInChildren<VisionCollider>();
    Scanner = GetComponent<ObstacleScanner>();
    targetSelector = GetComponent<TargetSelector>();
    movement = GetComponent<Movement>();
    RandomDir = Random.Range(-1, 1);
    RB = GetComponent<Rigidbody2D>();
  }

  public void ChooseAvoidanceDir()
  {
    Quaternion Right = Quaternion.AngleAxis(-50, Vector3.forward);
    dirRight = Right * Scanner.dirCenter;
    Quaternion Left = Quaternion.AngleAxis(50, Vector3.forward);
    dirLeft = Left * Scanner.dirCenter;

    if (targetSelector.Target != null)
      Scanner.ToTargetBeamLength = (targetSelector.Target.position - transform.position).magnitude;
    else
      Scanner.ToTargetBeamLength = Scanner.BeamLength;

    Vector2 moveDir = Vector2.zero;

    //bool useRight = true;
    //bool useLeft = true;

    //float DistanceMin = 100000;

    //foreach (var i in visionCollider.visibleObject)
    //{
    //  if (i.gameObject.layer == LayerMask.NameToLayer("Walls"))
    //  {
    //    ObjectDistance = i.Distance(Scanner.MyCollider).distance;
    //    if (ObjectDistance < DistanceMin)
    //    {
    //      DistanceMin = ObjectDistance;
    //    }
    //  }
    //}
    
    //if (Scanner.BeamCenter.distance < Scanner.BeamRight.distance && Scanner.BeamCenter.transform == targetSelector.Target)
    //  useRight = false;

    //if (Scanner.BeamCenter.distance < Scanner.BeamLeft.distance && Scanner.BeamCenter.transform == targetSelector.Target)
    //  useLeft = false;
    

    //if (DistanceMin < Scanner.radius * 0.5)
    //{
    //  Debug.Log("Pr potopim");
    //  if (RandomDir >= 0)
    //  {
    //    moveDir = Quaternion.AngleAxis(Random.Range(-80, -120), Vector3.forward) * Scanner.dirCenter;
    //  }
    //  else
    //  {
    //    moveDir = Quaternion.AngleAxis(Random.Range(80, 120), Vector3.forward) * Scanner.dirCenter;
    //  }
    //}



    if (Scanner.BeamCenter.transform == targetSelector.Target && (Scanner.BeamRight.transform == null || Scanner.BeamRight.transform == targetSelector.Target)
        && (Scanner.BeamLeft.transform == null || Scanner.BeamLeft.transform == targetSelector.Target))
    {
      moveDir = Scanner.dirCenter;
      //Debug.Log("Center");
    }
    else if ((Scanner.BeamLeft.transform == null || Scanner.BeamLeft.transform == targetSelector.Target) && (Scanner.BeamRight.transform != null || Scanner.TestStartPointRight != null))
    {
      moveDir = dirLeft;
      //Debug.Log("Left");
    }
    else if ((Scanner.BeamRight.transform == null || Scanner.BeamRight.transform == targetSelector.Target) && (Scanner.BeamLeft.transform != null || Scanner.TestStartPointLeft != null))
    {
      moveDir = dirRight;
      //Debug.Log("Right");
    }
    else if (Scanner.TestStartPointCenter != null || (Scanner.BeamCenter.transform != targetSelector.Target && Scanner.BeamRight.transform == null && Scanner.BeamLeft.transform == null))
    {
      //Debug.Log("A");
      if (RandomDir >= 0)
      {
        moveDir = Quaternion.AngleAxis(Random.Range(-80, -120), Vector3.forward) * Scanner.dirCenter;
      }
      else
      {
        moveDir = Quaternion.AngleAxis(Random.Range(80, 120), Vector3.forward) * Scanner.dirCenter;
      }
    }


    if (timeToFixError < 0f && (Scanner.BeamCenter.transform != null
                                && Scanner.BeamRight.transform != null
                                && Scanner.BeamLeft.transform != null
                                && Scanner.BeamLeft.transform != targetSelector.Target
                                && Scanner.BeamRight.transform != targetSelector.Target))
    {
      //Debug.Log("B");
      if (timeToFixError > 0f)
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
