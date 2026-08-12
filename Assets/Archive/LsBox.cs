using UnityEngine;

public class LsBox : LsEntity
{
  public override void OnDeath(LsEntity caster)
  {
    foreach (var it in m_items)
      caster.AddItem(it);

    base.OnDeath(caster);
  }
}
