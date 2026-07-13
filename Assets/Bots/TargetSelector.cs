using UnityEngine;
using System.Collections.Generic;

public class TargetSelector : MonoBehaviour
{
  /*
  VisionCollider vision;
  private int PriorityMax;
  public Transform Target;
  private Vector2 Distance;
  private float DistanceMin;

  [System.Serializable]
  public struct PriorityEntry
  {
    public string Tag;
    public int Priority;
  }

  public List<PriorityEntry> PriorityTable = new();

  void Start()
  {
    vision = GetComponentInChildren<VisionCollider>();
  }

  void Update()
  {
    PriorityMax = 0;
    Target = null;
    DistanceMin = 10000000000000; //просто большое число

    foreach (var i in vision.visibleObject)
    {
      Distance = i.transform.position - transform.position;

      foreach (var j in PriorityTable)
      {
        if (i.CompareTag(j.Tag) && j.Priority > PriorityMax)
        {
          DistanceMin = Distance.magnitude;
          Target = i.transform;
          PriorityMax = j.Priority;
        }
        else if (i.CompareTag(j.Tag) && j.Priority == PriorityMax && Distance.magnitude < DistanceMin)
        {
          DistanceMin = Distance.magnitude;
          Target = i.transform;
        }
      }
    }
  }
  */
}
