using UnityEngine;
using TMPro;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class DimikLife : MonoBehaviour
{
  static public DimikLife LocalPlayer
  {
    get;
    private set;
  }

  public GameObject Player;
  public Rigidbody2D RB;
  public float HP_Player = 100;
  public TMP_Text Text_HP_Player;
  public SpriteRenderer m_SpriteRenderer;
  public BoxCollider2D Dimik_Collider;

  void Start()
  {
    LocalPlayer = this;
  }

  public void OnDamage(float damage)
  {
    HP_Player -= damage;

    StopAllCoroutines();
    StartCoroutine(AnimDamage());
  }

  private IEnumerator AnimDamage()
  {
    for (int i = 0; i < 3; i += 1)
    {
      Color RedDamage = new Color(1f, 0.6745283f, 0.6745283f);

      m_SpriteRenderer.color = RedDamage;
      yield return new WaitForSeconds(0.16666f);

      m_SpriteRenderer.color = Color.white;
      yield return new WaitForSeconds(0.16666f);
    }
  }

  void Update()
  {
    Text_HP_Player.text = "" + HP_Player;

    if (HP_Player <= 0)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}
