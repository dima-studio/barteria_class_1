using UnityEngine;
using System.Collections;

public class TakingDamage : MonoBehaviour
{
  public int HP;
  private SpriteRenderer m_SpriteRenderer;

  void Start()
  {
    m_SpriteRenderer = GetComponent<SpriteRenderer>();
  }

  public void OnDamage(int damage)
  {
    HP -= damage;
    Death();
    //StopAllCoroutines();
    //StartCoroutine(AnimDamage());
  }

  public virtual void Death()
  {
    if (HP <= 0)
    {
      Destroy(gameObject);
    }
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

}
