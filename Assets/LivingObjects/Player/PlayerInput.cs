using UnityEngine;

public class PlayerInput : MonoBehaviour
{
  private Movement movement;

  void Start()
  {
    movement = GetComponent<Movement>();
  }

  void Update()
  {
    Vector2 dir = Vector2.zero;
    if (Input.GetKey(KeyCode.W))
      dir.y += 1;
    if (Input.GetKey(KeyCode.S))
      dir.y -= 1f;
    if (Input.GetKey(KeyCode.D))
      dir.x += 1f;
    if (Input.GetKey(KeyCode.A))
      dir.x -= 1f;

    dir.Normalize();

    movement.Movement_ADD(dir);
  }
}
