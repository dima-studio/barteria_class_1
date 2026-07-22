using UnityEngine;
using System.Collections.Generic;

public class AttackZone : VisionCollider
{
  public float Cooldown;
  public float CooldownSave;
  public int damage;
  private TakingDamage takingDamage;

  [System.Serializable]
  public struct AttackEntry
  {
    public string Tag;
  }
  public List<AttackEntry> AttackTable = new();

  void Start()
  {
    Cooldown = 0f;
  }

  private void Attack()
  {
    if (Cooldown <= 1f)
    {
      var newArrayVisibleObject = visibleObject.ToArray();
      foreach (var i in newArrayVisibleObject)
      {
        takingDamage = i.GetComponent<TakingDamage>();
        foreach (var j in AttackTable)
        {
          if (i.CompareTag(j.Tag))
          {
            takingDamage.OnDamage(damage);
            Cooldown = CooldownSave;
          }

        }
      }
    }
    else
    {
      Cooldown -= Time.deltaTime;
    }
  }

  void Update()
  {
    Attack();
  }
}
