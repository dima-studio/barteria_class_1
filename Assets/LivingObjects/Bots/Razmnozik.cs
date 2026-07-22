using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Razmnozik : MonoBehaviour
{
  public Rigidbody2D RB;
  public float timeDirection;
  public float speedEnemy = 1.8f;
  public GameObject m_Enemy;
  public float Reproduction_cooldown = 15f;
  public float Attack_cooldown = 1.5f;
  public CapsuleCollider2D Razmnozik_Collider;
  public float distanñå = 100f;
  public Collider2D triger_Reproduction;


  State stateUSE;
  Vector2 dir = Vector2.zero;

  enum State
  {
    Patrol,
    Reproduction,
    Attack

  }

  void Start()
  {
    timeDirection = 0;
    Reproduction_cooldown = Random.Range(15f, 20f);
    Attack_cooldown = 0;
    stateUSE = State.Patrol;

  }

  bool PlayerONtriger;
  bool RazmnozikONtriger;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      PlayerONtriger = true;
    }

    if (collision.CompareTag("Razmnoziks"))
    {
      RazmnozikONtriger = true;
    }
  }


  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      PlayerONtriger = false;
    }

    if (collision.CompareTag("Razmnoziks"))
    {
      RazmnozikONtriger = false;
    }
  }

  private void Movement_R()
  {
    timeDirection = timeDirection - Time.deltaTime;

    if (timeDirection <= 0)
    {
      float X = Random.Range(-1f, 1f);
      float Y = Random.Range(-1f, 1f);
      dir = new Vector2(X, Y);
      dir.Normalize();
      timeDirection = Random.Range(3f, 17f);
    }
    RB.linearVelocity = dir * speedEnemy;

  }

  void Update()
  {
    if (PlayerONtriger)
    {
      stateUSE = State.Attack;
    }
    else if (RazmnozikONtriger)
    {
      stateUSE = State.Reproduction;
    }
    else
    {
      stateUSE = State.Patrol;
    }

    /*
    float distanñå_Player = Razmnozik_Collider.Distance(DimikLife.LocalPlayer.Dimik_Collider).distance;
    
    
    if (triger_Reproduction == true)
    {
      stateUSE = State.Reproduction;
    }
    else if (triger_Reproduction == true)
    {
      stateUSE = State.Attack;
    }
    else
    {
      stateUSE = State.Patrol;
    }
    */

    if (stateUSE == State.Patrol)
    {
      Movement_R();
    }

    if (Reproduction_cooldown >= 0)
    {
      Reproduction_cooldown -= Time.deltaTime;
    }

    if (stateUSE == State.Reproduction)
    {
      Movement_R();
      if (Reproduction_cooldown <= 0)
      {
        Instantiate(m_Enemy);
        Reproduction_cooldown = Random.Range(12f, 20f);
      }

    }

    if (Attack_cooldown >= 0)
    {
      Attack_cooldown -= Time.deltaTime;
    }

    if (stateUSE == State.Attack)
    {
      Movement_R();
      if (Attack_cooldown <= 0)
      {
        //DimikLife.LocalPlayer.OnDamage(15);
        Attack_cooldown = 1f;
      }
    }

  }
}
