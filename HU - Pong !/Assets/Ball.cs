using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float adjustment;
    public TMP_Text p1Score;
    public TMP_Text p2Score;
    public int p1ScoreInt, p2ScoreInt;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * 10;
        p1ScoreInt = 0;
        p2ScoreInt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < player1.transform.position.x-adjustment)
        {
            transform.position = Vector2.zero;
            GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * 10;
            p2ScoreInt++;
            p1Score.text = $"Player 1: {p1ScoreInt}";
            p2Score.text = $"Player 2: {p2ScoreInt}";
        }

        if (transform.position.x > player2.transform.position.x+adjustment)
        {
            transform.position = Vector2.zero;
            GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * 10;
            p1ScoreInt++;
            p1Score.text = $"Player 1: {p1ScoreInt}";
            p2Score.text = $"Player 2: {p2ScoreInt}";
        }
    }
}
