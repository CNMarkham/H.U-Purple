using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] tetrominoes;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTetromino();
        //call function
    }

    public void SpawnTetromino()
    {
        int randNum = Random.Range(0, tetrominoes.Length);
        GameObject randomTetreomino = tetrominoes[randNum];
        Instantiate(randomTetreomino, transform.position, Quaternion.identity);
    }

}
