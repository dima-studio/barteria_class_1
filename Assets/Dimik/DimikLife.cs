using UnityEngine;

public class DimikLafe : MonoBehaviour
{
  public GameObject DimikObject;
  public float DimikSpeedMin = 1f;
  public float DimikSpeedMax = 4f;
  public float DimikRazgon = 2f;
  public Rigidbody2D RB;

  void Start()
  {

  }

  void Update()
  {
    Vector3 move = Vector3.zero;
    if (Input.GetKey(KeyCode.W))
      move.y += 1f;
    if (Input.GetKey(KeyCode.S))
      move.y -= 1f;
    if (Input.GetKey(KeyCode.D))
      move.x += 1f;
    if (Input.GetKey(KeyCode.A))
      move.x -= 1f;

    move.Normalize();

    if (move != Vector3.zero)
    {
      if (DimikSpeedMin < DimikSpeedMax)
      {
        DimikSpeedMin += DimikRazgon * Time.deltaTime;
      }
      RB.linearVelocity = move * DimikSpeedMin;
    }
    else
    {
      RB.linearVelocity = move * DimikSpeedMin;
      DimikSpeedMin = 1f;
    }

  }
}
