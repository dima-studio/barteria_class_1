using UnityEngine;

public class Movement : MonoBehaviour
{
  protected Rigidbody2D I_rb;
  public float Speed;

  void Start()
  { 
    OnStart();
  }

  protected virtual void OnStart()
  {
    I_rb = GetComponent<Rigidbody2D>();
  }


  public virtual void Movement_ADD(Vector2 dir)
  {
    I_rb.linearVelocity = Speed * dir;
  }

  void Update()
  {
    /*
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
    */
  }
}
