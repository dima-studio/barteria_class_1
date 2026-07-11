using UnityEngine;

public class Movement : MonoBehaviour
{
  private Rigidbody2D I_rb;
  public float ChangeSpeed;
  public float StartSpeed;

  public float Acceleration;
  Vector2 dir_result;
  public float MaxSpeed;

  void Start()
  {
    I_rb = GetComponent<Rigidbody2D>();
    StartSpeed = ChangeSpeed;
  }

  public void Movement_ADD(Vector2 dir)
  {
    I_rb.linearVelocity = ChangeSpeed * dir;
    dir_result = dir;
  }

  void Update()
  {
    if (Acceleration > 0f && dir_result != Vector2.zero)
    {
      ChangeSpeed += Acceleration * Time.deltaTime;
      if (ChangeSpeed > MaxSpeed)
      {
        ChangeSpeed = MaxSpeed;
      }
    }
    else
    {
      ChangeSpeed = StartSpeed;
    }
  }
}
