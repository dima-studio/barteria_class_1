using UnityEngine;

public class ObstacleScanner : MonoBehaviour
{
  public float BeamLength;

  [HideInInspector]
  public RaycastHit2D BeamCenter;
  public RaycastHit2D BeamRight;
  public RaycastHit2D BeamLeft;
  public Vector2 dirCenter;
  private Collider2D MyCollider;
  ObstacleAvoidance obstacleAvoidance;
  public float radius;
  public Collider2D TestStartPointCenter;


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

    radius = MyCollider.bounds.size.magnitude / 2f;
    LayerMask BeamMask = LayerMask.GetMask("Walls", "Bots", "Player");
    Vector2 CenterCollider = MyCollider.bounds.center;
    RaycastHit2D CenterStartPoint = Physics2D.Raycast(CenterCollider + dir * radius, dir, ToTargetBeamLength);
    BeamCenter = Physics2D.Raycast(CenterStartPoint.point, dir, ToTargetBeamLength, BeamMask);

    TestStartPointCenter = Physics2D.OverlapPoint(CenterStartPoint.point, BeamMask);

    Vector2 RightDir = Quaternion.AngleAxis(-90, Vector3.forward) * dir;
    Vector2 RightStartPoint = CenterStartPoint.point + RightDir.normalized * radius;
    BeamRight = Physics2D.Raycast(RightStartPoint, dir, ToTargetBeamLength - radius * 2, BeamMask);

    Vector2 LeftDir = Quaternion.AngleAxis(90, Vector3.forward) * dir;
    Vector2 LeftStartPoint = CenterStartPoint.point + LeftDir.normalized * radius;
    BeamLeft = Physics2D.Raycast(LeftStartPoint, dir, ToTargetBeamLength - radius * 2, BeamMask);

    obstacleAvoidance.ChooseAvoidanceDir();

    Debug.DrawLine(CenterStartPoint.point, CenterStartPoint.point + dir * (ToTargetBeamLength), Color.white);
    Debug.DrawLine(RightStartPoint, RightStartPoint + dir * (ToTargetBeamLength - radius * 2), Color.white);
    Debug.DrawLine(LeftStartPoint, LeftStartPoint + dir * (ToTargetBeamLength - radius * 2), Color.white);

    if (BeamCenter.collider != null)
      Debug.DrawLine(CenterStartPoint.point, BeamCenter.point, Color.red);

    if (BeamRight.collider != null)
      Debug.DrawLine(RightStartPoint, BeamRight.point, Color.red);
    
    if (BeamLeft.collider != null)
      Debug.DrawLine(LeftStartPoint, BeamLeft.point, Color.red);
  }

  void Update()
  {
  }
}
