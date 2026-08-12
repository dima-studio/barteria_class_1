using System.Collections.Generic;
using UnityEngine;

public class LsEntity : MonoBehaviour
{
  public float        m_hp    = 100f;
  public List<string> m_items = new List<string>();


  public virtual void DoDamage(LsEntity target)
  {
  }


  public virtual void AddItem(string item)
  {
    Debug.Log("получен предмет:" + item);
    m_items.Add(item);
  }
  
  public virtual void ApplyDamage(LsEntity caster, float damage)
  {
    if (m_hp <= 0)
      return;
    
    Debug.Log("получен урон:" + damage );
    m_hp -= damage;
    if  (m_hp <= 0)
      OnDeath(caster);
  }


  public virtual void OnDeath(LsEntity caster)
  {
    Debug.Log("Я умер!");
  }
}
