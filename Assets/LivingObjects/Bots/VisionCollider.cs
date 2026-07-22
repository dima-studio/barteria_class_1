using UnityEngine;
using System.Collections.Generic;

public class VisionCollider : MonoBehaviour
{
  public List<Collider2D> visibleObject = new();

  protected virtual void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.isTrigger)
    {
      return;
    }
    visibleObject.Add(collision);
  }

  protected virtual void OnTriggerExit2D(Collider2D collision)
  {
    visibleObject.Remove(collision);
  }
}
