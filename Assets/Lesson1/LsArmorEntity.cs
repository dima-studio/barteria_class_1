using UnityEngine;

public class LsArmorEntity : LsEntity
{
  public float m_armor = 20f;

    
  public override void ApplyDamage(LsEntity caster, float damage)
  {
    if (m_armor < 0f || m_armor > 100f)
      m_armor = 0f;

    damage = damage * ((100f - m_armor) / 100f);
    m_armor -= damage * 0.1f;

    base.ApplyDamage(caster, damage);
  }


  public override void OnDeath(LsEntity caster)
  {
    Debug.Log("Брони осталось:" + m_armor);
    base.OnDeath(caster);
  }

}
