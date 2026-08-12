using UnityEngine;

public class LsPlayer : LsArmorEntity
{
  public float        m_damage = 1f;
  public LsEntity     m_target = null;

  public override void DoDamage(LsEntity target)
  {
    if (m_target == null)
      return;

    target.ApplyDamage(this, m_damage);
    base.DoDamage(target);
  }


  public void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      DoDamage(m_target);
    }
  }
}
