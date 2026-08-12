using UnityEngine;

public class ObstacleAvoidance : MonoBehaviour
{
  ObstacleScanner obstacleScanner;

    void Start()
    {
        obstacleScanner = GetComponent<ObstacleScanner>();
    }



    void Update()
    {
    }
}
