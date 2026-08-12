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
  }
}
