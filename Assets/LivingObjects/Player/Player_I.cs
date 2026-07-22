using UnityEngine;

public class Player_I : MonoBehaviour
{
  static public Player_I LocalPlayer
  {
    get;
    private set;
  }

  void Start()
  {
    LocalPlayer = this;
  }
}
