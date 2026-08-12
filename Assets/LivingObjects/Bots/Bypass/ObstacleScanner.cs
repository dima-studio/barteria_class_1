using UnityEngine;

public class ObstacleScanner : MonoBehaviour
{
  public float BeamLength;

  [HideInInspector]
  public RaycastHit2D BeamCenter;
  public RaycastHit2D BeamRight;
  public RaycastHit2D BeamLeft;
  private Collider2D MyCollider;

  void Start()
  {
    MyCollider = GetComponent<Collider2D>();
  }

  public void ObstacleDetection(Vector2 dir)
  {
    float radius = MyCollider.bounds.size.magnitude / 2f;
    LayerMask BeamMask = LayerMask.GetMask("Walls", "Bots", "Player");
    Vector2 CenterCollider = MyCollider.bounds.center;
    RaycastHit2D StartBeam = Physics2D.Raycast(CenterCollider + dir * radius, dir, BeamLength);

    BeamCenter = Physics2D.Raycast(StartBeam.point, dir, BeamLength, BeamMask);

    Quaternion Right = Quaternion.AngleAxis(30, Vector3.forward);
    Vector2 dirRight = Right * dir;
    BeamRight = Physics2D.Raycast(StartBeam.point, dirRight, BeamLength, BeamMask);

    Quaternion Left = Quaternion.AngleAxis(-30, Vector3.forward);
    Vector2 dirLeft = Left * dir;
    BeamLeft = Physics2D.Raycast(StartBeam.point, dirLeft, BeamLength, BeamMask);

    if (BeamCenter || BeamRight || BeamLeft == true)
    {
    Debug.DrawLine(StartBeam.point, StartBeam.point + dir * BeamLength, Color.white);
    Debug.DrawLine(StartBeam.point, StartBeam.point + dirRight * BeamLength, Color.white);
    Debug.DrawLine(StartBeam.point, StartBeam.point + dirLeft * BeamLength, Color.white);
    //Debug.Log(BeamCenter.collider.gameObject.layer);
    }
  }

  void Update()
  {
  }
}
