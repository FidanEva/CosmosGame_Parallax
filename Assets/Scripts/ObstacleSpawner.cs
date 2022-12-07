using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles;
    void Start()
    {
        SpawnObstacle();
        InvokeRepeating("SpawnObstacle", 0f, 1f);
    }

    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int randomPos = Random.Range(0, 2);
        int randomObs = Random.Range(0, 2);

        Instantiate(_obstacles[randomObs], transform.GetChild(randomPos).transform.position + new Vector3(0, 9, 0), Quaternion.identity);
        transform.GetChild(randomPos).transform.position += new Vector3(0, 9, 0);
    }
}
