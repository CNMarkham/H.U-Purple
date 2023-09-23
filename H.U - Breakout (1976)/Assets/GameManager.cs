using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public float xSpace;
    public float xOffset;

    public GameObject brickPrefab;
    // Start is called before the first frame update
    void Start()
    {
        // a for loop has 3 parts a iterator, (or counting) variable, an end condition, and increment
        for (int x = 0; x < 10; x++)
        {   // the instantiate function has 3 parameters: the object you are spawning, where your spawning it, and the rotation.
            Instantiate(brickPrefab, new Vector2(x * xSpace + xOffset, 3), Quaternion.identity);
            Instantiate(brickPrefab, new Vector2(x * xSpace + xOffset, 3.75f), Quaternion.identity);
            Instantiate(brickPrefab, new Vector2(x * xSpace + xOffset, 4.5f), Quaternion.identity);

        }
    }
    // Update is called once per frame
}
    