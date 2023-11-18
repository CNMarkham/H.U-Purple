using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject rockPrefab;
    public Transform[] spawnPoints;
    private void SpawnRocks()
    {
        Vector3 randomPosition = spawnPoints[Random.Range(0, 5)].position;
        InvokeRepeating("SpawnRocks", 0f, 10f);
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++) //the 5 in this line is how you add more astroids to spawn 
        {
            Vector3 randomPosition = new Vector3(Random.Range(-8, 8), Random.Range(-8, 8), 0f);
            Instantiate(rockPrefab, randomPosition, Quaternion.identity);
        }
    }

}
