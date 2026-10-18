using UnityEngine;
using UnityEngine.EventSystems;

public class SliderSaveSetting : MonoBehaviour, IPointerUpHandler
{
  public void OnPointerUp(PointerEventData pointerEventData)
  {
    SaveSettingManager.SaveTotalSound();
  }
}
