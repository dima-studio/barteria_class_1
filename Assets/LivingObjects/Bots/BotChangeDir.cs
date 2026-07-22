using UnityEngine;

public class BotChangeDir : MonoBehaviour
{
  private float timeDirection = 0f;
  public float ChangeDirTimeMin;
  public float ChangeDirTimeMax;
  Movement movement;
  Vector2 dir;

  void Start()
  {
    movement = GetComponent<Movement>();
    dir = Vector2.zero;
  }

  void Update()
  {
    timeDirection = timeDirection - Time.deltaTime;

    if (timeDirection <= 0)
    {
      float X = Random.Range(-1f, 1f);
      float Y = Random.Range(-1f, 1f);
      dir = new Vector2(X, Y);
      dir.Normalize();
      timeDirection = Random.Range(ChangeDirTimeMin, ChangeDirTimeMax);
    }
    movement.Movement_ADD(dir);
  }
}
