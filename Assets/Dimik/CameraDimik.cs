using UnityEngine;

public class CameraDimik : MonoBehaviour
{
  Vector3 SpeedCamera;
  public Transform targetCamera;
  public float softnesCamera;

  void Start()
  {

  }

  void Update()
  {
    Vector3 pos = Vector3.SmoothDamp(transform.position, targetCamera.position, ref SpeedCamera, softnesCamera);
    pos.z = -10;
    transform.position = pos;
  }
}
