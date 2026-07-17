using UnityEngine;
using System.Collections.Generic;

public class AttackZone : MonoBehaviour
{
  VisionCollider vision;
  float Cooldown;
  public float CooldownSave;
  [System.Serializable]
  public struct AttackEntry
  {
    string Tag;
    float Damage;
  }
  public List<AttackEntry> AttackTable = new();

  void Start()
  {
    vision = GetComponentInChildren<VisionCollider>();
    Cooldown = 0f;
  }


  void Update()
  {
    if (Cooldown <= 0f)
    {

    }
    else
    {
      Cooldown -= Time.deltaTime;
    }
  }
}
