using UnityEngine;

public class AccelerationMov : Movement
{
  protected Vector2 dir_result;
  public float Acceleration;
  public float MaxSpeed;
  protected float StartSpeed;

  public override void Movement_ADD(Vector2 dir)
  {
    I_rb.linearVelocity = Speed * dir;
    dir_result = dir;

    if (Acceleration > 0f && dir_result != Vector2.zero)
    {
      Speed += Acceleration * Time.deltaTime;
      if (Speed > MaxSpeed)
      {
        Speed = MaxSpeed;
      }
    }
    else
    {
      Speed = StartSpeed;
    }
  }


  protected override void OnStart()
  {
    base.OnStart();
    StartSpeed = Speed;
  }

  void Update()
  {
  }
}
