using UnityEngine;
using System.Collections.Generic;

public class VisionCollider : MonoBehaviour
{
  public List<Collider2D> visibleObject = new();

  private void OnTriggerEnter2D(Collider2D collision)
  {
    visibleObject.Add(collision);
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    visibleObject.Remove(collision);
  }
}
