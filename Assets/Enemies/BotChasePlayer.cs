using UnityEngine;

public class BotChasePlayer : MonoBehaviour
{
  Vector2 dir = Vector2.zero;
  private bool PlayerONtriger;
  public Collider2D PursuitZone;
  public Movement movement;
  private BotChasePlayer Bot;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      PlayerONtriger = true;
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      PlayerONtriger = false;
    }
  }
  //коллайдеры, вызов ходьбы, что дальше
  void Start()
  {
    movement = GetComponent<Movement>();
    Bot = this;
  }

  void Update()
  {
    if (PlayerONtriger == true)
    {
      dir = DimikLife.LocalPlayer.transform.position - Bot.transform.position;
      movement.Movement_ADD(dir);
    }
  }
}
