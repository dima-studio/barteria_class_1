using UnityEngine;

public class BotChangeDir : MonoBehaviour
{
  public float timeDirection = 0f;
  public float ChangeDirTimeMin;
  public float ChangeDirTimeMax;
  Movement movement;
  public Vector2 dir;
  //private ObstacleScanner obstacleScanner;

  void Start()
  {
    //obstacleScanner = GetComponent<ObstacleScanner>();
    movement = GetComponent<Movement>();
    dir = Vector2.zero;
  }

  public void BotChangeDirActively()
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
    //obstacleScanner.ObstacleDetection(dir);
    movement.Movement_ADD(dir);
  }

  void Update()
  {
  }
}
