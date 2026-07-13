using UnityEngine;

public class Zlodey : MonoBehaviour
{
  public GameObject Player;
  public Rigidbody2D RB;
  public float timeDirection;
  public float speedEnemy = 2.2f;
  public GameObject m_Enemy;
  public float Attack_cooldown = 1.5f;
  public Collider2D Attack_Triger_collider;
  public Collider2D Chace_Triger_collider;

  State stateUSE;
  Vector2 dir = Vector2.zero;

  enum State
  {
    Patrol,
    Chace,
    Attack

  }

  void Start()
  {
    timeDirection = 0;
    Attack_cooldown = 0;
    stateUSE = State.Patrol;
  }

  /*
  bool Attack_Triger_ONiOFF = false;
  bool Chace_Triger_ONiOFF = false;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision == Attack_Triger_collider)
    {
      Attack_Triger_ONiOFF = true;
    }

    if (collision == Chace_Triger_collider)
    {
      Chace_Triger_ONiOFF = true;
    }
  }
  */

  private void Movement_Z()
  {
    timeDirection = timeDirection - Time.deltaTime;

    if (timeDirection <= 0)
    {
      float X = Random.Range(-1f, 1f);
      float Y = Random.Range(-1f, 1f);
      dir = new Vector2(X, Y);
      dir.Normalize();
      timeDirection = Random.Range(2f, 15f);
    }
    RB.linearVelocity = dir * speedEnemy;
  }

  void Update()
  {

    float distanñå = Vector2.Distance(transform.position, Player.transform.position);

    if (distanñå < 1.4)
    {
      stateUSE = State.Attack;
    }
    else if (distanñå < 5)
    {
      stateUSE = State.Chace;
    }
    else
    {
      stateUSE = State.Patrol;
    }

    if (stateUSE == State.Patrol)
    {
      Movement_Z();
    }

    if (stateUSE == State.Chace)
    {
      timeDirection = 0;
      dir = Player.transform.position - m_Enemy.transform.position;
      dir.Normalize();

      RB.linearVelocity = dir * speedEnemy;
    }

    if (Attack_cooldown >= 0)
    {
      Attack_cooldown -= Time.deltaTime;
    }

    if (stateUSE == State.Attack)
    {
      timeDirection = 0;
      dir = Player.transform.position - m_Enemy.transform.position;
      dir.Normalize();

      if (Attack_cooldown <= 0)
      {
        DimikLife.LocalPlayer.OnDamage(25);
        Attack_cooldown = 1.5f;
      }

      RB.linearVelocity = dir * speedEnemy;

    }


  }
}
