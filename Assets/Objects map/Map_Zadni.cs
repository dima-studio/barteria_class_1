using UnityEngine;

public class Map_Zadni : MonoBehaviour
{
  public GameObject Fon;
  public GameObject Player;

  void Start()
  {

  }

  void Update()
  {
    float width = Fon.GetComponent<SpriteRenderer>().bounds.size.x;
    if (Fon.transform.position.x < Player.transform.position.x - width * 1.5)
    {
      Fon.transform.position += new Vector3(width * 3, 0, 0);
    }

    if (Fon.transform.position.x > Player.transform.position.x + width * 1.5)
    {
      Fon.transform.position += new Vector3(width * -3, 0, 0);
    }

    float heigth = Fon.GetComponent<SpriteRenderer>().bounds.size.y;
    if (Fon.transform.position.y < Player.transform.position.y - heigth * 1.5)
    {
      Fon.transform.position += new Vector3(0, heigth * 3, 0);
    }

    if (Fon.transform.position.y > Player.transform.position.y + heigth * 1.5)
    {
      Fon.transform.position += new Vector3(0, heigth * -3, 0);
    }
  }
}


