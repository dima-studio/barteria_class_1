using UnityEngine;

public class ObstacleScanner : MonoBehaviour
{
  public float BeamLength;

  [HideInInspector]
  public RaycastHit2D BeamCenter;
  public RaycastHit2D BeamRight;
  public RaycastHit2D BeamLeft;
  public Vector2 dirRight;
  public Vector2 dirLeft;
  public Vector2 dirCenter;
  private Collider2D MyCollider;
  ObstacleAvoidance obstacleAvoidance;

  public float ToTargetBeamLength
  {
    get;
    set;
  }


  void Start()
  {
    ToTargetBeamLength = BeamLength;
    MyCollider = GetComponent<Collider2D>();
    obstacleAvoidance = GetComponent<ObstacleAvoidance>();
  }

  public void ObstacleDetection(Vector2 dir)
  {
    dirCenter = dir;

    float radius = MyCollider.bounds.size.magnitude / 2f;
    LayerMask BeamMask = LayerMask.GetMask("Walls", "Bots", "Player");
    Vector2 CenterCollider = MyCollider.bounds.center;
    RaycastHit2D StartBeam = Physics2D.Raycast(CenterCollider + dir * radius, dir, ToTargetBeamLength);

    BeamCenter = Physics2D.Raycast(StartBeam.point, dir, ToTargetBeamLength, BeamMask);

    Quaternion Right = Quaternion.AngleAxis(50, Vector3.forward);
    dirRight = Right * dir;

    Vector2 rightDir = Quaternion.AngleAxis(90, Vector3.forward) * dir;
    Vector2 rightStartPoint = StartBeam.point + rightDir.normalized * radius;
    BeamRight = Physics2D.Raycast(rightStartPoint, dir, ToTargetBeamLength, BeamMask);

    Quaternion Left = Quaternion.AngleAxis(-50, Vector3.forward);
    dirLeft = Left * dir;

    Vector2 leftDir = Quaternion.AngleAxis(-90, Vector3.forward) * dir;
    Vector2 leftStartPoint = StartBeam.point + leftDir.normalized * radius;
    BeamLeft = Physics2D.Raycast(leftStartPoint, dir, ToTargetBeamLength, BeamMask);


    obstacleAvoidance.ChooseAvoidanceDir();

    if (BeamCenter.collider != null || BeamRight.collider != null || BeamLeft.collider != null)
    {
    Debug.DrawLine(StartBeam.point, StartBeam.point + dir * ToTargetBeamLength, Color.white);
    Debug.DrawLine(rightStartPoint, rightStartPoint + dir * ToTargetBeamLength, Color.white);
    Debug.DrawLine(leftStartPoint, leftStartPoint + dir * ToTargetBeamLength, Color.white);

    Debug.DrawLine(StartBeam.point, BeamCenter.point, Color.red);
    Debug.DrawLine(rightStartPoint, BeamRight.point, Color.red);
    Debug.DrawLine(leftStartPoint, BeamLeft.point, Color.red);
    //Debug.Log(BeamCenter.collider.gameObject.layer);
    }
  }

  void Update()
  {
  }
}
